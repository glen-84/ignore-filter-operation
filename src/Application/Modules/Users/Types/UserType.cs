namespace Application.Modules.Users.Types;

using Application.Modules.Users.Entities;
using Application.Modules.Users.Services;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(u => u.Id)
            .Type<IdType>();

        descriptor.Field(u => u.EmailAddress)
            .Type<NonNullType<EmailAddressType>>();

        descriptor.Field(u => u.Username);

        descriptor.Field(u => u.UserIpAddresses)
            .IsProjected(false)
            .ResolveWith<UserType>(u => UserIpAddresses(default!, default!));
    }

    private static IQueryable<UserIpAddress> UserIpAddresses(
        [Parent] User user,
        [Service] UserService userService)
    {
        return userService.GetUserIpAddressesByUserId(user.Id);
    }
}
