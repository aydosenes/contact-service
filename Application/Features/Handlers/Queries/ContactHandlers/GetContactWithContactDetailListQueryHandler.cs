using Application.Dtos;
using Application.Features.Queries;
using Application.Features.Queries.ContactQueries;
using Application.Features.Request.Queries.ContactQueries;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Queries.ContactHandlers
{
    public class GetContactWithContactDetailListQueryHandler : IRequestHandler<GetContactWithContactDetailListQuery, IDataResult<ContactWithContactDetailListDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public GetContactWithContactDetailListQueryHandler(IContactRepository contactRepository, IMapper mapper, IContactDetailRepository contactDetailRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactDetailRepository = contactDetailRepository;
        }

        public async Task<IDataResult<ContactWithContactDetailListDto>> Handle(GetContactWithContactDetailListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(request.Id);
                var mappedContact = _mapper.Map<ContactDto>(contact);
                var details = await _contactDetailRepository.GetListAsync(s=> contact.ContactDetailIdList.Contains(s.Id));
                var mappedDetails = _mapper.Map<List<ContactDetailDto>>(details);
                return new SuccessDataResult<ContactWithContactDetailListDto>(new ContactWithContactDetailListDto()
                {
                    Contact = mappedContact, ContactDetailList = mappedDetails 
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactWithContactDetailListDto>(ex.Message);
            }

        }
    }
}
