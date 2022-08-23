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
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, IDataResult<Contact>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public AddContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<Contact>> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapped = _mapper.Map<Contact>(request.Contact);
                var result = await _contactRepository.AddAsync(mapped);
                return new SuccessDataResult<Contact>(result, Messages.Success_Added);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Contact>(ex.Message);
            }
        }
    }
}
