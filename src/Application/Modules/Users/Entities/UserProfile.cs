namespace Application.Modules.Users.Entities;

using Application.Modules.Core.Entities;

public class UserProfile
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public short? RegionId { get; set; }

    public string? AboutMe { get; set; }

    public Region? Region { get; set; }

    public User User { get; set; } = null!;
}
