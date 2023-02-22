using MediatR;
using TestApp.Domain.Models.Authors;

namespace TestApp.Domain.Queries.Authors
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorModel>>
    {
    }
}
