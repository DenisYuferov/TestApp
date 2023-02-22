using MediatR;
using TestApp.Domain.Models.Books;

namespace TestApp.Domain.Commands.Books
{
    public class AddBookCommand : IRequest<AddBookModel>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int AuthorId { get; set; }
    }
}
