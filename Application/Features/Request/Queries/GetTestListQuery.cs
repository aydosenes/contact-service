using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Queries
{
    public class GetTestListQuery : IRequest<IDataResult<List<TestDto>>>
    {
    }
}
