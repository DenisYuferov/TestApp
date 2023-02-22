using AutoMapper;
using MediatR;
using TestApp.Domain.Models.Authors;
using TestApp.Domain.Queries.Authors;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Authors
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }
        public async Task<List<GetAuthorModel>> Handle(GetAuthorsQuery request, CancellationToken cancellation)
        {
            var authors = await _unitOfWork.AuthorRepository.AllAsync(null, cancellation);

            return _mapper.Map<List<GetAuthorModel>>(authors);
        }
    }
}
