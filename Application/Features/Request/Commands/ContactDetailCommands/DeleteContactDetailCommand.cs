using Application.Dtos;
using Application.Results;
using MediatR;

namespace Application.Features.Request.Commands.ContactDetailCommands
{
    public class DeleteContactDetailCommand : IRequest<IDataResult<ContactDetailDto>>
    {
        public ContactDetailDto ContactDetail { get; set; }
    }
}
