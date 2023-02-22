using AutoMapper;
using MediatR;
using TestApp.Domain.Commands.Books;
using TestApp.Domain.Models.Books;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Books
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<AddBookModel> Handle(AddBookCommand request, CancellationToken cancellation)
        {
            var book = _mapper.Map<Book>(request);

            var entity = await _unitOfWork.BookRepository.AddAsync(book, cancellation);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AddBookModel>(entity);
        }
    }
}
