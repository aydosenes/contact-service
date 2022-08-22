using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class DeleteContactCommand : IRequest<IDataResult<Contact>>
    {
    }
}
