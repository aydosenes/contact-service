using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Request.Queries.ContactDetailQueries
{
    public class GetContactDetailListQuery : IRequest<IDataResult<List<ContactDetailDto>>>
    {
    }
}
