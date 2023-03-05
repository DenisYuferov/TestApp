using MediatR;
using TestApp.Domain.Model.Dtos.Authors;

namespace TestApp.Domain.Model.Commands.Authors
{
    public class AddAuthorCommand : IRequest<AddAuthorDto>
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
