using AutoMapper;
using MediatR;
using TestApp.Domain.Abstraction.UnitOfWorks;
using TestApp.Domain.Model.Commands.Books;
using TestApp.Domain.Model.Entities;
using TestApp.Domain.Model.Dtos.Books;

namespace TestApp.Domain.Handlers.Books
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookDto>
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
        public async Task<AddBookDto> Handle(AddBookCommand request, CancellationToken cancellation)
        {
            var book = _mapper.Map<Book>(request);

            var entity = await _unitOfWork.BookRepository.AddAsync(book, cancellation);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AddBookDto>(entity);
        }
    }
}
