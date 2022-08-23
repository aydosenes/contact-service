using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Queries.ContactQueries
{
    public class GetContactWithContactDetailListQuery : IRequest<IDataResult<ContactWithContactDetailListDto>>
    {
        public string Id { get; set; }
    }
}

