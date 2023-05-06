using Domain.Common;

namespace Domain.Entities;

public class Project : BaseEntity
{
    public string? Name { get; set; }
    public int Bpm { get; set; }
    public string? TimeSig { get; set; }
    public List<Track>? Tracks { get; set; }
}
