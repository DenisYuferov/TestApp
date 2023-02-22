using MediatR;
using TestApp.Domain.Models.Authors;

namespace TestApp.Domain.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorWithBooksModel>
    {
        public int Id { get; set; }
    }
}
