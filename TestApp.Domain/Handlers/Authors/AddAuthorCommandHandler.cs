using AutoMapper;
using MediatR;
using TestApp.Domain.Abstraction.UnitOfWorks;
using TestApp.Domain.Model.Commands.Authors;
using TestApp.Domain.Model.Entities;
using TestApp.Domain.Model.Views.Authors;

namespace TestApp.Domain.Handlers.Authors
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorView>
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
        public async Task<AddAuthorView> Handle(AddAuthorCommand request, CancellationToken cancellation)
        {
            var author = _mapper.Map<Author>(request);

            var entity = await _unitOfWork.AuthorRepository.AddAsync(author, cancellation);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AddAuthorView>(entity);
        }
    }
}
