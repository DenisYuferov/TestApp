using MediatR;
using TestApp.Domain.Models.Authors;

namespace TestApp.Domain.Commands.Authors
{
    public class AddAuthorCommand : IRequest<AddAuthorModel>
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
