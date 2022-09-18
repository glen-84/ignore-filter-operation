namespace Application.Modules.Users.Validators.Rules;

using System.Text.RegularExpressions;
using Application.Modules.Users.Inputs;
using Application.Modules.Users.Services;
using FluentValidation;

public static class UserRules
{
    /// <summary>Unicode letters, 0-9, ".", "-", and "_".</summary>
    private static readonly Regex UsernameRegex = new(@"^[\p{L}0-9\.\-_]*$", RegexOptions.Compiled);

    public static IRuleBuilderOptions<T, string?> UserEmailAddress<T>(
        this IRuleBuilder<T, string?> ruleBuilder,
        UserService userService)
    {
        return ruleBuilder
            .NotNull()
            .MaximumLength(60)
            .EmailAddress()
            .MustAsync(async (input, emailAddress, ct) =>
            {
                return await userService.IsUniqueEmailAddress(
                    emailAddress,
                    excludedUserId: input is UpdateUserInput updateUserInput ? updateUserInput.Id : null,
                    ct);

                // todo localization
            }).WithMessage("The email address '{PropertyValue}' has already been used.");
    }

    public static IRuleBuilderOptions<T, string?> UserUsername<T>(
        this IRuleBuilder<T, string?> ruleBuilder,
        UserService userService)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(20)
            .Matches(UsernameRegex)
            .MustAsync(async (input, username, ct) =>
            {
                return await userService.IsUniqueUsername(
                    username,
                    excludedUserId: input is UpdateUserInput updateUserInput ? updateUserInput.Id : null,
                    ct);

                // todo localization
            }).WithMessage("The username '{PropertyValue}' has already been used.");
    }
}
