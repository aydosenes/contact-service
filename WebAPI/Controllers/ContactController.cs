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

        /// <summary>
        /// Adds a new contact.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add-contact")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddContact([FromBody] AddContactCommand request)
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

    }
}
