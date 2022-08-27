using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Request.Commands
{
    public class AddRangeReportCommand
    {
        public ICollection<ReportDto> Report { get; set; }
    }
}
