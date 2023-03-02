using FluentValidation;
using TestApp.Domain.Model.Commands.Books;

namespace TestApp.Domain.Validators.Books
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(b => b.Id).GreaterThan(0);

            RuleFor(b => b.AuthorId).GreaterThan(0);

            RuleFor(a => a.Title).NotNull().NotEmpty().MaximumLength(512);

            RuleFor(a => a.Description).MaximumLength(1024);

            RuleFor(a => a.Cost).GreaterThan(0).When(a => a.Cost.HasValue);
        }
    }
}
