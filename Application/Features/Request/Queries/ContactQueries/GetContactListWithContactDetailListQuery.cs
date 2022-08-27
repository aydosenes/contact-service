using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Queries.ContactQueries
{
    public class GetReportQuery : IRequest<IDataResult<ContactListWithContactDetailListDto>>
    {
        public GetContactListWithContactDetailListQuery GetContactListWithContactDetailListQuery { get; set; }
    }
}

