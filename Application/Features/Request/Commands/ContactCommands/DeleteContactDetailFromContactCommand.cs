using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class DeleteContactDetailFromContactCommand : IRequest<IDataResult<Contact>>
    {
        public ContactIdAndContactDetailIdPairDto ContactDetailToContact { get; set; }
    }
}
