using MediatR;
using TestApp.Domain.Model.Views.Authors;

namespace TestApp.Domain.Model.Queries.Authors
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorView>>
    {
    }
}
