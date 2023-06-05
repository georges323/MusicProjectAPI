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

        var storageKeys = tracksList
            .Where(t => t.StorageKey != null)
            .Select(t => t.StorageKey)
            .ToList();

        var storageKeysToUrl = _fileService.GetFilesUrls(storageKeys, 5);

         return tracksList.Select(t => new TrackDto
        {
            Id = t.Id,
            Name = t.Name,
            WavUrl = GetUrlFromDictionary(t.StorageKey, storageKeysToUrl),
            ProjectId = t.ProjectId
        }).ToList();
    }

    private string? GetUrlFromDictionary(string? storageKey, Dictionary<string,string> storageKeysToUrl)
    {
        if (storageKey == null) return null;

        return storageKeysToUrl.TryGetValue(storageKey, out string wavUrl) ? wavUrl : null;
    }
}
