using MediatR;

namespace TestApp.Domain.Model.CQRS.Commands.Authors
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
