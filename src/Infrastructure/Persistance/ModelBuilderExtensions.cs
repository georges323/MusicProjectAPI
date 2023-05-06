using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder builder)
    {
        var projectId = Guid.NewGuid();

        builder.Entity<Project>().HasData(new Project
        {
            Id = projectId,
            Name = "Drowning",
            Bpm = 155,
            TimeSig = "4/4"
        });

        builder.Entity<Track>().HasData(new Track
        {
            Id = Guid.NewGuid(),
            Name = "Guitar",
            ProjectId = projectId
        });

        builder.Entity<Track>().HasData(new Track
        {
            Id = Guid.NewGuid(),
            Name = "Drums",
            ProjectId = projectId
        });
        
        builder.Entity<Track>().HasData(new Track
        {
            Id = Guid.NewGuid(),
            Name = "Vocals",
            ProjectId = projectId
        });
    }
}
