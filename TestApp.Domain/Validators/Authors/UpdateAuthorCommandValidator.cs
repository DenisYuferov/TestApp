using FluentValidation;
using TestApp.Domain.Commands.Authors;

namespace TestApp.Domain.Validators.Authors
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() 
        {
            RuleFor(a => a.Id).GreaterThan(0);

            RuleFor(a => a.Age).InclusiveBetween(10, 100);

            RuleFor(a => a.FirstName).NotNull().NotEmpty().MaximumLength(16);

            RuleFor(a => a.LastName).MaximumLength(64);

            RuleFor(a => a.Phone).MaximumLength(32);
        }
    }
}
