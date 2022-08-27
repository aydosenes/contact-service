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
    public class AddContactWithDetailCommandHandler : IRequestHandler<AddContactWithDetailCommand, IDataResult<ContactWithContactDetailListDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public AddContactWithDetailCommandHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }
        public async Task<IDataResult<ContactWithContactDetailListDto>> Handle(AddContactWithDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedContactDetail = _mapper.Map<List<ContactDetail>>(request.ContactWithContactDetailList.ContactDetailList);
                var detail = await _contactDetailRepository.AddRangeAsync(mappedContactDetail);
                var mappedContact = _mapper.Map<Contact>(request.ContactWithContactDetailList.Contact);
                foreach (var item in detail)
                {
                    mappedContact.ContactDetailIdList.Add(item.Id);
                }
                var contact = await _contactRepository.AddAsync(mappedContact);
                foreach (var d in mappedContactDetail)
                {
                    d.ContactId = contact.Id;
                }
                var updatedDetail = await _contactDetailRepository.UpdateRangeAsync(mappedContactDetail);
                var contactDto = _mapper.Map<ContactDto>(contact);
                var detailDto = _mapper.Map<List<ContactDetailDto>>(updatedDetail);

                return new SuccessDataResult<ContactWithContactDetailListDto>(new ContactWithContactDetailListDto() { Contact = contactDto, ContactDetailList = detailDto }, Messages.Success_Added);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactWithContactDetailListDto>(ex.Message);
            }
        }
    }
}
