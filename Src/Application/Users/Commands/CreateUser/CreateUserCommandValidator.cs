using FluentValidation;

namespace ProductsCleanArch.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email).MaximumLength(50).EmailAddress().NotEmpty();
            RuleFor(x => x.Occupation).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.FullName).MaximumLength(50).NotEmpty();
        }
    }
}