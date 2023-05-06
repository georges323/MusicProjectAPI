using Domain.Common;

namespace Domain.Entities;

public class Track : BaseEntity
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ProjectId { get; set; }
}
