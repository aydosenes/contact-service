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

namespace Application.Features.Handlers
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, BaseResult>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public DeleteTestCommandHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<BaseResult> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var test = await _testRepository.GetByIdAsync(request.Id);
                await _testRepository.DeleteAsync(test);
                return new SuccessResult(Messages.Success_Deleted);

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
    }
}
