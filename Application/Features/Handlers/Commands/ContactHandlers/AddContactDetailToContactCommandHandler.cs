using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;
using Application.Features.Request.Commands.ContactCommands;

namespace Application.Features.Handlers.Commands.ContactHandlers
{
    public class AddContactDetailToContactCommandHandler : IRequestHandler<AddContactDetailToContactCommand, IDataResult<ContactDetailToContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public AddContactDetailToContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<ContactDetailToContactDto>> Handle(AddContactDetailToContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(request.ContactDetailToContact.ContactId);
                contact.ContactDetailIdList.Add(request.ContactDetailToContact.ContactDetailId);
                await _contactRepository.UpdateAsync(contact);
                return new SuccessDataResult<ContactDetailToContactDto>(request.ContactDetailToContact, Messages.Success_Added);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactDetailToContactDto>(request.ContactDetailToContact, ex.Message);
            }
        }
    }
}
