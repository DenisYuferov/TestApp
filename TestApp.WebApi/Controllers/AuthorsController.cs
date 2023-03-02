using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Model.Commands.Authors;
using TestApp.Domain.Model.Queries.Authors;

namespace TestApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthorsController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellation)
        {
            var query = new GetAuthorByIdQuery { Id = id };
            var result = await _sender.Send(query, cancellation);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellation)
        {
            var result = await _sender.Send(new GetAuthorsQuery(), cancellation);

            return Ok(result);
        }        

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddAuthorCommand command, CancellationToken cancellation)
        {
            var result = await _sender.Send(command, cancellation);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateAuthorCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteAuthorCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }
    }
}