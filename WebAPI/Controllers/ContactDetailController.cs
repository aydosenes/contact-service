using Application.Dtos;
using Application.Features.Queries.ContactQueries;
using Application.Features.Request.Commands.ContactCommands;
using Application.Features.Request.Commands.ContactDetailCommands;
using Application.Features.Request.Queries.ContactDetailQueries;
using Application.Features.Request.Queries.ContactQueries;
using Application.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("contact-detail/{id}")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<ContactDetailDto>>))]
        public async Task<IActionResult> ContactDetailById(string id)
        {
            var result = await _mediator.Send(new GetContactDetailByIdQuery() { Id = id });
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("contact-detail-list")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<ContactDetailDto>>))]
        public async Task<IActionResult> ContactDetailList()
        {
            var result = await _mediator.Send(new GetContactDetailListQuery());
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost("add-contact-detail")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddContactDetail([FromBody] AddContactDetailCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("update-contact-detail")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> UpdateContactDetail([FromBody] UpdateContactDetailCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpDelete("delete-contact-detail")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> DeleteContactDetail([FromBody] DeleteContactDetailCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
