using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CastList()
        {
            var values = await _mediator.Send(new GetCastQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cast ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Cast silme işlemi başarılı.");
        }

        [HttpGet("GetCast")]
        public async Task<IActionResult> GetCast(int id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cast güncelleme işlemi başarılı.");
        }
    }
}
