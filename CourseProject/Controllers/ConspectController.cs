﻿using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CourseProject.Web.Api.Controllers
{
    [Route("api/Conspect")]
    public class ConspectController : Controller
    {
        private readonly IMediator _mediator;

        public ConspectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Conspect
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetConspects.Query()));
        }

        // GET: api/Conspect/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConspect([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetConspect.Query
            {
                Id = id
            }));
        }

        // PUT: api/Conspect/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConspect([FromBody] UpdateConspect.Command command)
        {
            command.UserClaims = User;
            return Ok(await _mediator.Send(command));
        }

        // POST: api/Conspect
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateConspect([FromBody] CreateConspect.Command command)
        {
            command.UserClaims = User;
            return Ok(await _mediator.Send(command));
        }

        // DELETE: api/Conspect/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConspect([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteConspect.Command
            {
                Id = id
            }));
        }
    }
}