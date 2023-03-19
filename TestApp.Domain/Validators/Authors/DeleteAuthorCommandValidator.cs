using FluentValidation;
using TestApp.Domain.Model.CQRS.Commands.Authors;

namespace TestApp.Domain.Validators.Authors
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator() 
        {
            RuleFor(a => a.Id).GreaterThan(0);
        }
    }
}
