using Application.Dtos;
using Application.Features.Queries;
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
    public class GetTestListQueryHandler : IRequestHandler<GetTestListQuery, IDataResult<List<TestDto>>>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public GetTestListQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<TestDto>>> Handle(GetTestListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _testRepository.GetListAsync();
                var result = _mapper.Map<List<TestDto>>(test);
                return new SuccessDataResult<List<TestDto>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<TestDto>>(ex.Message);
            }

        }
    }
}
