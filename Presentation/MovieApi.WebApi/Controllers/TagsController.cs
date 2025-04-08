﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }

        [HttpGet("GetTag")]
        public async Task<IActionResult> GetTag(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag ekleme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Tag silme işlemi başarılı.");
        }
    }
}
