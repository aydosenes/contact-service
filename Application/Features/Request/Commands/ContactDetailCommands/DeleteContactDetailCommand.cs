using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactDetailCommands
{
    public class DeleteContactDetailCommand : IRequest<IDataResult<ContactDetail>>
    {
        public ContactDetailDto ContactDetail { get; set; }
    }
}
