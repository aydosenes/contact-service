using Application.Features.Request.Commands;
using Application.Interfaces.Repository;
using Application.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Commands
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, BaseResult>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public UpdateTestCommandHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<BaseResult> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _testRepository.GetByIdAsync(request.Id);
                _mapper.Map(request, test);
                await _testRepository.UpdateAsync(test);
                return new SuccessResult(Messages.Success_Updated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
    }
}
