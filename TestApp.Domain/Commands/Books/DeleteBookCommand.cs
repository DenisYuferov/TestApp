using MediatR;

namespace TestApp.Domain.Commands.Books
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
