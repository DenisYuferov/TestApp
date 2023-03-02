using MediatR;

namespace TestApp.Domain.Model.Commands.Authors
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
