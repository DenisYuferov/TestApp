using MediatR;
using TestApp.Domain.Model.Dtos.Books;

namespace TestApp.Domain.Model.Queries.Books
{
    public class GetBookByIdQuery : IRequest<GetBookWithAuthorDto>
    {
        public int Id { get; set; }
    }
}
