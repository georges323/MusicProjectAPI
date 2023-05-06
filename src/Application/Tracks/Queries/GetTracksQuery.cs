using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tracks.Queries;

public record GetTracksQuery(Guid ProjectId) : IRequest<List<TrackDto>>;

public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, List<TrackDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTracksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TrackDto>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
    {
        var tracksList = await _context.Tracks
            .Where(t => t.ProjectId == request.ProjectId)
            .ToListAsync();

        return tracksList.Select(t => new TrackDto
        {
            Id = t.Id,
            Name = t.Name,
            ImageUrl = t.ImageUrl,
            ProjectId = t.ProjectId
        }).ToList();
    }
}
