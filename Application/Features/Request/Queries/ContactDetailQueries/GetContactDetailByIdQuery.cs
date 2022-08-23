using System;
using Application.Dtos;
using Application.Results;
using MediatR;

namespace Application.Features.Request.Queries.ContactDetailQueries
{
    public class GetContactDetailByIdQuery : IRequest<IDataResult<ContactDetailDto>>
    {
        public string Id { get; set; }
    }
}
