namespace Application.Modules.Users.Inputs;

public class UpdateUserInput
{
    public int Id { get; set; }

    [DefaultValue("example@example.com")]
    [GraphQLType(typeof(NonNullType<EmailAddressType>))]
    public Optional<string> EmailAddress { get; init; }

    [DefaultValue("")]
    public Optional<string> Username { get; init; }
}
