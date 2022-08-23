using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class DeleteContactCommand : IRequest<IDataResult<Contact>>
    {
        public ContactDto Contact { get; set; }
    }
}
