using Application.Dtos;
using Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Features.Request.Commands
{
    public class AddRangeReportCommand : IRequest<IDataResult<MemoryStream>>
    {
        public ICollection<ReportDto> Report { get; set; }
    }
}
