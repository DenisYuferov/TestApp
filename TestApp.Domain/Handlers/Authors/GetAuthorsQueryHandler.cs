using AutoMapper;

using MediatR;

using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Domain.Model.CQRS.Dtos.Authors;
using TestApp.Domain.Model.CQRS.Queries.Authors;

namespace TestApp.Domain.Handlers.Authors
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<GetAuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellation)
        {
            var authors = await _unitOfWork.AuthorRepository.AllAsync(null, cancellation);

            return _mapper.Map<List<GetAuthorDto>>(authors);
        }
    }
}
