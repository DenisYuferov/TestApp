using AutoMapper;
using MediatR;
using TestApp.Domain.Commands.Books;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellation)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellation);

            _mapper.Map(request, book);

            await _unitOfWork.SaveAsync();
        }
    }
}
