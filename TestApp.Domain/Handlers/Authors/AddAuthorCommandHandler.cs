using AutoMapper;
using MediatR;
using TestApp.Domain.Commands.Authors;
using TestApp.Domain.Models.Authors;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Authors
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<AddAuthorModel> Handle(AddAuthorCommand request, CancellationToken cancellation)
        {
            var author = _mapper.Map<Author>(request);

            var entity = await _unitOfWork.AuthorRepository.AddAsync(author, cancellation);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AddAuthorModel>(entity);
        }
    }
}
