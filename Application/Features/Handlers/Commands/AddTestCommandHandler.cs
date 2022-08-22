using Application.Features.Request.Commands;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers
{
    public class AddTestCommandHandler : IRequestHandler<AddTestCommand, BaseResult>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public AddTestCommandHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }
        public async Task<BaseResult> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _testRepository.AddAsync(_mapper.Map<Test>(request));
                return new SuccessResult(Messages.Success_Added);

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
