namespace Application.Modules.Users.Types;

using Application.Modules.Users.Entities;
using Application.Modules.Users.Services;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class UserQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers([Service] UserService userService)
    {
        return userService.GetUsers();
    }

    [NodeResolver]
    public async Task<User?> GetUserById(
        int id,
        [Service] UserService userService,
        CancellationToken cancellationToken)
    {
        return await userService.GetUserById(id, cancellationToken);
    }
}
