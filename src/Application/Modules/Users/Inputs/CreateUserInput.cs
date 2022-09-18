namespace Application.Modules.Users.Inputs;

public class CreateUserInput
{
    [GraphQLType(typeof(NonNullType<EmailAddressType>))]
    public string EmailAddress { get; init; } = null!;
}
