using Application.Features.Request.Commands.ContactCommands;
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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, IDataResult<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<ContactDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _contactRepository.UpdateAsync(_mapper.Map<Contact>(request.Contact));
                return new SuccessDataResult<ContactDto>(request.Contact, Messages.Success_Updated);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactDto>(request.Contact, ex.Message);
            }
        }
    }
}