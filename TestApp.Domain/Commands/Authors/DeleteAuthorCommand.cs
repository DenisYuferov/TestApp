using MediatR;

namespace TestApp.Domain.Commands.Authors
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
