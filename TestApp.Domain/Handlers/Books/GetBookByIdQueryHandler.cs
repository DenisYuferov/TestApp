using AutoMapper;

using MediatR;

using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Domain.Model.CQRS.Dtos.Books;
using TestApp.Domain.Model.CQRS.Queries.Books;

namespace TestApp.Domain.Handlers.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookWithAuthorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetBookWithAuthorDto> Handle(GetBookByIdQuery request, CancellationToken cancellation)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellation);

            return _mapper.Map<GetBookWithAuthorDto>(book);
        }
    }
}
