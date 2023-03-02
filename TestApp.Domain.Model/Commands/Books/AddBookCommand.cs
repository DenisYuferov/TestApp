using MediatR;
using TestApp.Domain.Model.Views.Books;

namespace TestApp.Domain.Model.Commands.Books
{
    public class AddBookCommand : IRequest<AddBookView>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int AuthorId { get; set; }
    }
}
