using MediatR;
using TestApp.Domain.Model.CQRS.Dtos.Authors;

namespace TestApp.Domain.Model.CQRS.Commands.Authors
{
    public class AddAuthorCommand : IRequest<AddAuthorDto>
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
