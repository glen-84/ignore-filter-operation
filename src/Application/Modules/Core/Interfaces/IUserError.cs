namespace Application.Modules.Core.Interfaces;

[GraphQLName("UserError")]
public interface IUserError
{
    public string Code { get; }

    public string Message { get; }

    public string MessagePattern { get; }

    public IReadOnlyDictionary<string, object?> MessageArguments { get; }
}
