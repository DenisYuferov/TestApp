using FluentValidation;
using TestApp.Domain.Model.Commands.Books;

namespace TestApp.Domain.Validators.Books
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator() 
        {
            RuleFor(b => b.Id).GreaterThan(0);
        }
    }
}
