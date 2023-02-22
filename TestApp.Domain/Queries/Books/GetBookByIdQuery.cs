using MediatR;
using TestApp.Domain.Models.Books;

namespace TestApp.Domain.Queries.Books
{
    public class GetBookByIdQuery : IRequest<GetBookWithAuthorModel>
    {
        public int Id { get; set; }
    }
}
