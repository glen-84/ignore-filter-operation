namespace Application.Modules.Users.Mutations;

using Application.Modules.Users.Entities;
using Application.Modules.Users.Inputs;
using Application.Modules.Users.Services;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class UserMutations
{
    public Task<User> CreateUser(
        [Service] UserService userService,
        CreateUserInput input,
        CancellationToken ct)
    {
        return userService.CreateUser(input, ct);
    }

    public Task<User> UpdateUser(
        [Service] UserService userService,
        UpdateUserInput input,
        CancellationToken ct)
    {
        return userService.UpdateUser(input, ct);
    }
}
