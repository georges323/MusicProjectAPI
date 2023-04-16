using Domain.Common;

namespace Domain.Entities;

public class Project : BaseAuditableEntity
{
    public string? Name { get; set; }
    public int Bpm { get; set; }
    public string? TimeSig { get; set; }
}
