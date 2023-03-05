using MediatR;
using TestApp.Domain.Model.Dtos.Authors;

namespace TestApp.Domain.Model.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorWithBooksDto>
    {
        public int Id { get; set; }
    }
}
