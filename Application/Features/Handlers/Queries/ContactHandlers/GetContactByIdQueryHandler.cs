using Application.Dtos;
using Application.Features.Request.Queries;
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

namespace Application.Features.Handlers.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, IDataResult<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ContactDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _contactRepository.GetByIdAsync(request.Id);
                var result = _mapper.Map<ContactDto>(test);
                return new SuccessDataResult<ContactDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContactDto>(ex.Message);
            }
        }
    }
}
