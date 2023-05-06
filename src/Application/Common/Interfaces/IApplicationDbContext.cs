using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Project> Projects { get; }
    DbSet<Track> Tracks { get; }
}
