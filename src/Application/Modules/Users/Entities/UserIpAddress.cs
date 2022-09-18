namespace Application.Modules.Users.Entities;

public partial class UserIpAddress
{
    public UserIpAddress(string ipAddress)
    {
        this.IpAddress = ipAddress;
    }

    public long Id { get; set; }

    public int? UserId { get; set; }

    public string IpAddress { get; set; }

    public DateTime LoggedAt { get; set; }

    public virtual User? User { get; set; }
}
