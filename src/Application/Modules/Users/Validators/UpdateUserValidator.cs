namespace Application.Modules.Users.Validators;

using Application.Modules.Users.Inputs;
using Application.Modules.Users.Services;
using Application.Modules.Users.Validators.Rules;
using FluentValidation;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserInput>
{
    public UpdateUserValidator(UserService userService)
    {
        // todo RuleForOptional(() => Optional<T> ...) to remove need for `When` and `Value` ?
        this.RuleFor(u => u.EmailAddress.Value)
            .UserEmailAddress(userService)
            .When(u => u.EmailAddress.HasValue);

        this.RuleFor(u => u.Username.Value)
            .UserUsername(userService)
            .When(u => u.Username.HasValue);
    }
}
