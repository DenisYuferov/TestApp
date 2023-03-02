using MediatR;

namespace TestApp.Domain.Model.Commands.Authors
{
    public class UpdateAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
    }
}
