namespace Application.Modules.Users.Services;

using System.Security.Cryptography;
using Application.Modules.Core.Persistence;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Inputs;
using Microsoft.EntityFrameworkCore;

public sealed class UserService : IAsyncDisposable
{
    private readonly ApplicationDbContext dbContext;

    public UserService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        this.dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<User> GetUsers()
    {
        return this.dbContext.Users.AsQueryable();
    }

    public async Task<User?> GetUserById(int id, CancellationToken cancellationToken)
    {
        return await this.dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User> CreateUser(CreateUserInput input, CancellationToken ct)
    {
        using var sha256 = SHA256.Create();

        // Generate a temporary username.
        var username = "user-" + Convert.ToHexString(sha256.ComputeHash(Guid.NewGuid().ToByteArray()))[..15];

        var user = new User(input.EmailAddress, username);

        this.dbContext.Users.Add(user);

        await this.dbContext.SaveChangesAsync(ct);

        return user;
    }

    public async Task<User> UpdateUser(UpdateUserInput input, CancellationToken ct)
    {
        var user = await this.dbContext.Users.SingleOrDefaultAsync(u => u.Id == input.Id, ct);

        if (user is null)
        {
            throw new Exception("tmp, user not found");//tmp
        }

        //todo move to mapping method/class
        if (input.EmailAddress.HasValue)
        {
            user.EmailAddress = input.EmailAddress.Value!; //todo
        }

        if (input.Username.HasValue)
        {
            user.Username = input.Username.Value!; //todo
        }
        // --

        await this.dbContext.SaveChangesAsync(ct);

        return user;
    }

    public async Task<bool> IsUniqueEmailAddress(
        string emailAddress,
        int? excludedUserId,
        CancellationToken ct)
    {
        var users = this.dbContext.Users.AsQueryable();

        if (excludedUserId is not null)
        {
            users = users.Where(u => u.Id != excludedUserId);
        }

        return !await users.AnyAsync(u => u.EmailAddress == emailAddress, ct);
    }

    public async Task<bool> IsUniqueUsername(
        string username,
        int? excludedUserId,
        CancellationToken ct)
    {
        var users = this.dbContext.Users.AsQueryable();

        if (excludedUserId is not null)
        {
            users = users.Where(u => u.Id != excludedUserId);
        }

        return !await users.AnyAsync(u => u.Username == username, ct);
    }

    public IQueryable<UserIpAddress> GetUserIpAddressesByUserId(int userId)
    {
        return this.dbContext.UserIpAddresses.Where(a => a.UserId == userId);
    }

    public ValueTask DisposeAsync()
    {
        return this.dbContext.DisposeAsync();
    }
}
