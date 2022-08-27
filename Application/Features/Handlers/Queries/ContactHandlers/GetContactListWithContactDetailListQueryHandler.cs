using Application.Dtos;
using Application.Features.Request.Queries.ContactQueries;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Queries.ContactHandlers
{
    public class GetContactListWithContactDetailListQueryHandler : IRequestHandler<GetReportQuery, IDataResult<ContactListWithContactDetailListDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public GetContactListWithContactDetailListQueryHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }

        public async Task<IDataResult<ContactListWithContactDetailListDto>> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contactWithContactDetailListDto = new List<ContactWithContactDetailListDto>();
                var dto = new ContactListWithContactDetailListDto() { ContactWithContactDetailListDto = contactWithContactDetailListDto };
                
                var contacts = await _contactRepository.GetListAsync();
                foreach (var contact in contacts)
                {
                    var details = await _contactDetailRepository.GetListAsync(s => contact.ContactDetailIdList.Contains(s.Id));
                    var mappedContact = _mapper.Map<ContactDto>(contact);
                    var mappedDetails = _mapper.Map<List<ContactDetailDto>>(details);
                    dto.ContactWithContactDetailListDto.Add(new ContactWithContactDetailListDto() { 
                        Contact = mappedContact,
                        ContactDetailList = mappedDetails
                    });
                }               
                
                return new SuccessDataResult<ContactListWithContactDetailListDto>(dto);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactListWithContactDetailListDto>(ex.Message);
            }

        }
    }
}