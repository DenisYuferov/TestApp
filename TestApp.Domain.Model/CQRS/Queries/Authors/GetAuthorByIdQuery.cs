using MediatR;
using TestApp.Domain.Model.CQRS.Dtos.Authors;

namespace TestApp.Domain.Model.CQRS.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorWithBooksDto>
    {
        public int Id { get; set; }
    }
}
