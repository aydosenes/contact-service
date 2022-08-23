using Application.Dtos;
using Application.Features.Request.Queries;
using Application.Features.Request.Queries.ContactDetailQueries;
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

namespace Application.Features.Handlers.Queries.ContactDetailHandlers
{
    public class GetContactDetailListQueryHandler : IRequestHandler<GetContactDetailByIdQuery, IDataResult<ContactDetailDto>>
    {
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;
        public GetContactDetailListQueryHandler(IContactDetailRepository contactRepository, IMapper mapper)
        {
            _contactDetailRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ContactDetailDto>> Handle(GetContactDetailByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _contactDetailRepository.GetListAsync();
                var result = _mapper.Map<ContactDetailDto>(test);
                return new SuccessDataResult<ContactDetailDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactDetailDto>(ex.Message);
            }
        }
    }
}