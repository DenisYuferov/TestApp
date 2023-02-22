using AutoMapper;
using MediatR;
using TestApp.Domain.Commands.Authors;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Domain.Handlers.Authors
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellation)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id, cancellation);
            
            _mapper.Map(request, author);

            await _unitOfWork.SaveAsync();
        }
    }
}
