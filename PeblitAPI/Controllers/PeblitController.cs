using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeblitAPI.Application.PeblitItemCommand;
using PeblitAPI.Domain.Entities;

namespace PeblitAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeblitController : ControllerBase
    {
        public IMediator _mediator { get; set; }

        public PeblitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/CadastrarParametros")]
        public async Task<ActionResult> Post([FromBody] CadastrarParametrosCommand command)
        {
            var result = await _mediator.Send(command, default);
            return Ok(result);
        }

        [HttpPut("/AlterarParametros")]
        public async Task<ActionResult> Put([FromBody] AlterarParametrosCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("/AlterarRoupa")]
        public async Task<ActionResult> Put([FromBody] AlterarRoupaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("/DeletarParametros")]
        public async Task<ActionResult> Delete([FromBody] DeletarParametrosCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("/ListarParametrosPorID")]
        public async Task<PeblitItem> Get([FromQuery] int id)
        {
            var command = new ListarParametrosCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpGet("/ListarTodosParametros")]
        public async Task<IEnumerable<PeblitItem>> Get()
        {
            var command = new ListarTodosParametrosCommand();
            return await _mediator.Send(command);
        }
    }
}
