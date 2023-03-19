using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SharedInfrastructure.Model.Authorizations;
using TestApp.Domain.Model.CQRS.Commands.Books;
using TestApp.Domain.Model.CQRS.Queries.Books;

namespace TestApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ISender _sender;

        public BooksController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [Authorize(Roles = RoleLevelSets.UserLevel)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellation)
        {
            var query = new GetBookByIdQuery { Id = id };
            var result = await _sender.Send(query, cancellation);

            return Ok(result);
        }

        [Authorize(Roles = RoleLevelSets.AdminLevel)]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddBookCommand command, CancellationToken cancellation)
        {
            var result = await _sender.Send(command, cancellation);

            return Ok(result);
        }

        [Authorize(Roles = RoleLevelSets.AdminLevel)]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }

        [Authorize(Roles = RoleLevelSets.AdminLevel)]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteBookCommand command, CancellationToken cancellation)
        {
            await _sender.Send(command, cancellation);

            return Ok();
        }
    }
}