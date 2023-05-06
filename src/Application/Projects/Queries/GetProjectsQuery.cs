using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Queries;

public record GetProjectsQuery : IRequest<List<ProjectDto>>;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProjectsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projectsResult = await _context.Projects.ToListAsync(cancellationToken);

        return projectsResult.Select(pr => new ProjectDto
        {
            Id = pr.Id,
            Name = pr.Name,
            TimeSig = pr.TimeSig,
            Bpm = pr.Bpm
        }).ToList();
    }
}

