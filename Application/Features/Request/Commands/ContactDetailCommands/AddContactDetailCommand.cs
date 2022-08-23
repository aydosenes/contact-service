using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands.ContactDetailCommands
{
    public class AddContactDetailCommand : IRequest<IDataResult<ContactDetailDto>>
    {
        public ContactDetailDto ContactDetail { get; set; }
    }
}
