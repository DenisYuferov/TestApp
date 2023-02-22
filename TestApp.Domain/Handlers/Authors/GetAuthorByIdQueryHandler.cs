using AutoMapper;
using MediatR;
using TestApp.Domain.Models.Authors;
using TestApp.Domain.Queries.Authors;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Authors
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorWithBooksModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAuthorWithBooksModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellation)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellation);

            return _mapper.Map<GetAuthorWithBooksModel>(author);
        }
    }
}
