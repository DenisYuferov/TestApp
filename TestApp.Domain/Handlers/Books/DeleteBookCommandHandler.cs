using MediatR;

using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Domain.Model.CQRS.Commands.Books;

namespace TestApp.Domain.Handlers.Books
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellation)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellation);

            _unitOfWork.BookRepository.Remove(book);

            await _unitOfWork.SaveAsync();
        }
    }
}
