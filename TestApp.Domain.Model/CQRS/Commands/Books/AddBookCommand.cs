using MediatR;
using TestApp.Domain.Model.CQRS.Dtos.Books;

namespace TestApp.Domain.Model.CQRS.Commands.Books
{
    public class AddBookCommand : IRequest<AddBookDto>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int AuthorId { get; set; }
    }
}
