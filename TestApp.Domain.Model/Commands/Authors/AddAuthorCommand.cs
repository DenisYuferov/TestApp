using MediatR;
using TestApp.Domain.Model.Views.Authors;

namespace TestApp.Domain.Model.Commands.Authors
{
    public class AddAuthorCommand : IRequest<AddAuthorView>
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
