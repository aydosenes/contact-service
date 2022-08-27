using Application.Dtos;
using Application.Features.Queries.ContactQueries;
using Application.Features.Request.Commands.ContactCommands;
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
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("contact/{id}")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<ContactDto>>))]
        public async Task<IActionResult> ContactById(string id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery() { Id = id });
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("contact-list")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<ContactDto>>))]
        public async Task<IActionResult> ContactList()
        {
            var result = await _mediator.Send(new GetContactListQuery());
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost("add-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddContact([FromBody] AddContactCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("add-contact-with-detail")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddContactWithDetail([FromBody] AddContactWithDetailCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("update-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpDelete("delete-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> DeleteContact([FromBody] DeleteContactCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("add-contact-detail-to-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddContactDetailToContact([FromBody] AddContactDetailToContactCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("delete-contact-detail-from-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> DeleteContactDetailFromContact([FromBody] DeleteContactDetailFromContactCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("contact-list-with-contact-details")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<ContactWithContactDetailListDto>>))]
        public async Task<IActionResult> ContactWithContactDetails([FromBody] GetContactWithContactDetailListQuery request)
        {
            var result = await _mediator.Send(request);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }
    }
}
