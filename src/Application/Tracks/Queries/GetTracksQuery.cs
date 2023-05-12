using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tracks.Queries;

public record GetTracksQuery(Guid ProjectId) : IRequest<List<TrackDto>>;

public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, List<TrackDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public GetTracksQueryHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<List<TrackDto>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
    {
        var tracksList = await _context.Tracks
            .Where(t => t.ProjectId == request.ProjectId)
            .ToListAsync();

        var fileNames = tracksList
            .Select(t => t.StorageKey)
            .ToList();

        var trackNamesToUrl = _fileService.GetFilesUrls(fileNames, 5);

        return tracksList.Select(t => new TrackDto
        {
            Id = t.Id,
            Name = t.Name,
            WavUrl = trackNamesToUrl.TryGetValue(t.StorageKey, out string wavUrl) ? wavUrl : null,
            ProjectId = t.ProjectId
        }).ToList();
    }
}
