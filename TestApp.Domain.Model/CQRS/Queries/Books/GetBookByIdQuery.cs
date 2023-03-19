using MediatR;
using TestApp.Domain.Model.CQRS.Dtos.Books;

namespace TestApp.Domain.Model.CQRS.Queries.Books
{
    public class GetBookByIdQuery : IRequest<GetBookWithAuthorDto>
    {
        public int Id { get; set; }
    }
}
