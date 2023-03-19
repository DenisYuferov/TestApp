using MediatR;
using TestApp.Domain.Model.CQRS.Dtos.Authors;

namespace TestApp.Domain.Model.CQRS.Queries.Authors
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorDto>>
    {
    }
}
