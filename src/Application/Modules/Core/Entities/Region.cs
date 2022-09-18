namespace Application.Modules.Core.Entities;

public sealed class Region
{
    public Region(string m49Code, string name)
    {
        this.M49Code = m49Code;
        this.Name = name;
    }

    public short Id { get; set; }

    /// <summary>Gets or sets the M49 code of the region.</summary>
    /// <seealso href="https://unstats.un.org/unsd/methodology/m49/">M49 Standard</seealso>
    public string M49Code { get; set; }

    public string Name { get; set; }
}
