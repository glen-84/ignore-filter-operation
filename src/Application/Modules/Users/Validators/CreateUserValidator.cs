namespace Application.Modules.Users.Validators;

using Application.Modules.Users.Inputs;
using Application.Modules.Users.Services;
using Application.Modules.Users.Validators.Rules;
using FluentValidation;

public sealed class CreateUserValidator : AbstractValidator<CreateUserInput>
{
    public CreateUserValidator(UserService userService)
    {
        this.RuleFor(u => u.EmailAddress)
            .UserEmailAddress(userService);
    }
}
