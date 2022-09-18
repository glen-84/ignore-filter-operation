namespace Application.Modules.Users.Entities;

public sealed class User
{
    public User()
    {
    }

    public User(string emailAddress, string username)
    {
        this.EmailAddress = emailAddress;
        this.Username = username;

        this.UserIpAddresses = new HashSet<UserIpAddress>();
    }

    public int Id { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public string Username { get; set; } = null!;

    public string UsernameSlug { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public DateTime? RegistrationCompletedAt { get; set; }

    public DateTime LastActionAt { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? FusionAuthId { get; set; }

    public UserProfile Profile { get; set; } = null!;

    public ICollection<UserIpAddress> UserIpAddresses { get; } = null!;
}
