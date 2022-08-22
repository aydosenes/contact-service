using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Queries.ContactQueries
{
    public class GetContactListQuery : IRequest<IDataResult<List<ContactDto>>>
    {
    }
}
