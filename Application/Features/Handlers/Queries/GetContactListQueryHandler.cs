using Application.Dtos;
using Application.Features.Queries;
using Application.Features.Queries.ContactQueries;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, IDataResult<List<ContactDto>>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetContactListQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<ContactDto>>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _contactRepository.GetListAsync();
                var result = _mapper.Map<List<ContactDto>>(test);
                return new SuccessDataResult<List<ContactDto>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ContactDto>>(ex.Message);
            }

        }
    }
}
