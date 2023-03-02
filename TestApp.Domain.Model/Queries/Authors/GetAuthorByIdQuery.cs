using MediatR;
using TestApp.Domain.Model.Views.Authors;

namespace TestApp.Domain.Model.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorWithBooksView>
    {
        public int Id { get; set; }
    }
}
