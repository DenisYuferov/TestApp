using MediatR;
using TestApp.Domain.Model.Dtos.Authors;

namespace TestApp.Domain.Model.Queries.Authors
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorDto>>
    {
    }
}
