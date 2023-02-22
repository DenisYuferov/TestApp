using AutoMapper;
using MediatR;
using TestApp.Domain.Models.Books;
using TestApp.Domain.Queries.Books;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookWithAuthorModel>
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
        public async Task<GetBookWithAuthorModel> Handle(GetBookByIdQuery request, CancellationToken cancellation)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellation);

            return _mapper.Map<GetBookWithAuthorModel>(book);
        }
    }
}
