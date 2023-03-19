using MediatR;
using TestApp.Domain.Abstraction.Postgre.UnitOfWorks;
using TestApp.Domain.Model.CQRS.Commands.Authors;

namespace TestApp.Domain.Handlers.Authors
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellation)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellation);

            _unitOfWork.AuthorRepository.Remove(author);

            await _unitOfWork.SaveAsync();
        }
    }
}
