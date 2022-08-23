using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class AddContactDetailToContactCommand : IRequest<IDataResult<Contact>>
    {
        public ContactWithContactDetailDto ContactIdAndContactDetailIdPairDto { get; set; }
    }
}
