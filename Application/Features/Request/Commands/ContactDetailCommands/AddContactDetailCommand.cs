using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands.ContactDetailCommands
{
    public class AddContactDetailCommand : IRequest<IDataResult<ContactDetail>>
    {
        public ContactDetailDto ContactDetail { get; set; }
    }
}
