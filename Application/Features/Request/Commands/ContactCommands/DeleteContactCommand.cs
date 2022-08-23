using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class DeleteContactCommand : IRequest<IDataResult<ContactDto>>
    {
        public ContactDto Contact { get; set; }
    }
}
