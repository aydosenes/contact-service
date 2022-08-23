using Application.Dtos;
using Application.Results;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class AddContactDetailToContactCommand : IRequest<IDataResult<ContactDetailToContactDto>>
    {

        public ContactDetailToContactDto ContactDetailToContact { get; set; }
    }
}
