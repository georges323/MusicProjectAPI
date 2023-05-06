using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Queries;

public record GetProjectQuery(Guid Id) : IRequest<ProjectDto?>;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto?>
{
    private readonly IApplicationDbContext _context;

    public GetProjectQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectDto?> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var projectsResult = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (projectsResult == null)
        {
            return null;
        }

        return new ProjectDto
        {
            Id = projectsResult.Id,
            Name = projectsResult.Name,
            TimeSig = projectsResult.TimeSig,
            Bpm = projectsResult.Bpm
        };
    }
}

