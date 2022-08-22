using Application.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class UpdateContactCommand : IRequest<IDataResult<Contact>>
    {
    }
}