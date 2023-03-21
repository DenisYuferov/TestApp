using AutoMapper;

using MediatR;

using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Domain.Model.CQRS.Dtos.Authors;
using TestApp.Domain.Model.CQRS.Queries.Authors;

namespace TestApp.Domain.Handlers.Authors
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorWithBooksDto>
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
        public async Task<GetAuthorWithBooksDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellation)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellation);

            return _mapper.Map<GetAuthorWithBooksDto>(author);
        }
    }
}
