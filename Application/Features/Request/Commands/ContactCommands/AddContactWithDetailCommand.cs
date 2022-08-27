using Application.Dtos;
using Application.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Request.Commands.ContactCommands
{
    public class AddContactWithDetailCommand : IRequest<IDataResult<ContactWithContactDetailListDto>>
    {
        public ContactWithContactDetailListDto ContactWithContactDetailList { get; set; }
    }
}
