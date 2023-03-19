using MediatR;

namespace TestApp.Domain.Model.CQRS.Commands.Books
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
