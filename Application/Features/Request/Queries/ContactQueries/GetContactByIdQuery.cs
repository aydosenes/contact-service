using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Queries.ContactQueries
{
    public class GetContactByIdQuery : IRequest<IDataResult<ContactDto>>
    {
        public string Id { get; set; }
    }
}
