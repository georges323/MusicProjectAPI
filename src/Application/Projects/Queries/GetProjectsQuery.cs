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
        // maybe get projects by user Id later?
        var result = await _context.Projects.ToListAsync(cancellationToken);

        throw new NotImplementedException();
    }
}

