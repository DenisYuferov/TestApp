using FluentValidation;
using TestApp.Domain.Model.Commands.Authors;

namespace TestApp.Domain.Validators.Authors
{
    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidator() 
        {
            RuleFor(a => a.Age).InclusiveBetween(10, 100);

            RuleFor(a => a.FirstName).NotNull().NotEmpty().MaximumLength(16);

            RuleFor(a => a.LastName).MaximumLength(64);

            RuleFor(a => a.Phone).MaximumLength(32);
        }
    }
}
