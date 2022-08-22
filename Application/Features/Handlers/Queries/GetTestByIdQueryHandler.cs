using Application.Dtos;
using Application.Features.Request.Queries;
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
    public class GetTestByIdQueryHandler : IRequestHandler<GetTestByIdQuery, IDataResult<TestDto>>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public GetTestByIdQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<TestDto>> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _testRepository.GetByIdAsync(request.Id);
                var result = _mapper.Map<TestDto>(test);
                return new SuccessDataResult<TestDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TestDto>(ex.Message);
            }
        }
    }
}
