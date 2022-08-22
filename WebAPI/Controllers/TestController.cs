using Application.Dtos;
using Application.Features.Queries;
using Application.Features.Request.Commands;
using Application.Features.Request.Queries;
using Application.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("test/{id}")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<TestDto>>))]
        public async Task<IActionResult> TestById(string id)
        {
            var result = await _mediator.Send(new GetTestByIdQuery() { Id = id });
            if(result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("test-list")]
        [ProducesResponseType(200, Type = typeof(IDataResult<List<TestDto>>))]
        public async Task<IActionResult> TestList()
        {
            var result = await _mediator.Send(new GetTestListQuery());
            if(result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpPost("add-test")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> AddTest(AddTestCommand request)
        {
            var result = await _mediator.Send(request);
            if(result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("update-test")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> UpdateTest(UpdateTestCommand request)
        {
            var result = await _mediator.Send(request);
            if(result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpDelete("delete-test")]
        [ProducesResponseType(200, Type = typeof(BaseResult))]
        public async Task<IActionResult> DeleteTest(DeleteTestCommand request)
        {
            var result = await _mediator.Send(request);
            if(result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
