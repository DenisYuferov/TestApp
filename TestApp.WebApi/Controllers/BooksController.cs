using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Commands.Books;
using TestApp.Domain.Queries.Books;

namespace TestApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ISender _sender;

        public BooksController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellation)
        {
            var query = new GetBookByIdQuery { Id = id };
            var result = await _sender.Send(query, cancellation);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddBookCommand command, CancellationToken cancellation)
        {
            var result = await _sender.Send(command, cancellation);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteBookCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }
    }
}