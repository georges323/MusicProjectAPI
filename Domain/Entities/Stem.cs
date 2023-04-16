using Domain.Common;

namespace Domain.Entities;

public class Stem : BaseAuditableEntity
{
    public string? Name { get; set; }
}
