using MediatR;

namespace TestApp.Domain.Model.Commands.Books
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int AuthorId { get; set; }
    }
}
