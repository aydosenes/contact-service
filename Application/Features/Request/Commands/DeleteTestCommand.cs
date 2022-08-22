using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands
{
    public class DeleteTestCommand : IRequest<BaseResult>
    {
        public string Id { get; set; }
    }
}
