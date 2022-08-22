using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands
{
    public class AddTestCommand : IRequest<BaseResult>
    {
        public string JobId { get; set; }
        public int TestNo { get; set; }
        public string TestName { get; set; }
    }
}
