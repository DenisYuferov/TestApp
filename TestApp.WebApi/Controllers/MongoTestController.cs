using Microsoft.AspNetCore.Mvc;

using TestApp.Domain.Model.MongoDb.Entities;
using TestApp.Infrastructure.MongoDb.Repositories;

namespace TestApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MongoTestController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public MongoTestController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _bookRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _bookRepository.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Book book)
        {
            await _bookRepository.CreateAsync(book);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Book book)
        {
            await _bookRepository.UpdateAsync(book?.Id!, book!);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _bookRepository.RemoveAsync(id);

            return Ok();
        }

        private void TestApp()
        {

        }
    }
}