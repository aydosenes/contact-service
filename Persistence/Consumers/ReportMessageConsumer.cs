using Application.Dtos;
using Application.Features.Request.Commands;
using Application.Features.Request.Queries.ContactQueries;
using Application.Interfaces.Service;
using Domain.Common;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Consumers
{
    public class ReportMessageConsumer : IConsumer<GetContactListWithContactDetailListQuery>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IMediator _mediator;
        private readonly IRestService _restService;
        public ReportMessageConsumer(ISendEndpointProvider sendEndpointProvider, IMediator mediator, IRestService restService)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _mediator = mediator;
            _restService = restService;
        }
        public async Task Consume(ConsumeContext<GetContactListWithContactDetailListQuery> context)
        {
            var result = await _mediator.Send(new GetReportQuery() { GetContactListWithContactDetailListQuery = context.Message });
            if (result.Success)
            {
                var url = "http://localhost:5000/report-service/report/add-range-report";

                var reportList = new List<ReportDto>();
                var dto = result.Data.ContactWithContactDetailListDto;
                var groupedDetailList = dto.SelectMany(s => s.ContactDetailList).GroupBy(g => g.Location.Trim().ToLower()).ToList();
                foreach (var groupedDetail in groupedDetailList)
                {
                    reportList.Add(new ReportDto()
                    {
                        Location = groupedDetail.Key,
                        PhoneCount = groupedDetail.Count(),
                        ContactCount = groupedDetail.Select(s => s.ContactId).Distinct().ToList().Count,
                        State = Enums.State.Completed
                    });
                }
                await _restService.Post(url, new AddRangeReportCommand() { Report = reportList });
            }
        }
    }
}
