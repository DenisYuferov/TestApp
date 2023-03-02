using MediatR;
using TestApp.Domain.Model.Views.Books;

namespace TestApp.Domain.Model.Queries.Books
{
    public class GetBookByIdQuery : IRequest<GetBookWithAuthorView>
    {
        public int Id { get; set; }
    }
}
