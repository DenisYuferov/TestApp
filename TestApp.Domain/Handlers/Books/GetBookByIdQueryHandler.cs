using AutoMapper;
using MediatR;
using TestApp.Domain.Abstraction.UnitOfWorks;
using TestApp.Domain.Model.Queries.Books;
using TestApp.Domain.Model.Views.Books;

namespace TestApp.Domain.Handlers.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookWithAuthorView>
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
        public async Task<GetBookWithAuthorView> Handle(GetBookByIdQuery request, CancellationToken cancellation)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id, cancellation);

            return _mapper.Map<GetBookWithAuthorView>(book);
        }
    }
}
