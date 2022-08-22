using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands
{
    public class UpdateTestCommand : IRequest<BaseResult>
    {
        public string Id { get; set; }
        public int TestNo { get; set; }
        public string TestName { get; set; }

    }
}
