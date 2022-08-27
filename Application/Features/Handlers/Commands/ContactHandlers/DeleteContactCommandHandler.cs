﻿using Application.Features.Request.Commands.ContactCommands;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using System;
using System.Collections.Generic;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;

namespace Application.Features.Handlers.Commands.ContactHandlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, IDataResult<Contact>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public DeleteContactCommandHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<IDataResult<Contact>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var detail = await _contactDetailRepository.GetListAsync(x => x.ContactId == request.Contact.Id);
                var delete = await _contactDetailRepository.DeleteRangeAsync(detail);
                var result = await _contactRepository.DeleteAsync(_mapper.Map<Contact>(request.Contact));
                return new SuccessDataResult<Contact>(result, Messages.Success_Deleted);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }
    }
}
