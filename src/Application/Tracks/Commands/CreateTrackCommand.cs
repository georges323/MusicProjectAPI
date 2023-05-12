using Application.Common.Interfaces;
using Application.Tracks.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Tracks.Commands;

public record CreateTrackCommand(IFormFile File, Guid ProjectId) : IRequest<TrackDto>;

public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, TrackDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public CreateTrackCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }
    public async Task<TrackDto> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
    {
        var storageKey = await _fileService.UploadFile(request.File);

        var entity = new Track
        {
            Id = Guid.NewGuid(),
            Name = request.File.FileName,
            StorageKey = storageKey,
            ProjectId = request.ProjectId,
        };

        _context.Tracks.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new TrackDto
        {
            Id = entity.Id,
            Name = entity.Name,
            WavUrl = entity.StorageKey,
            ProjectId = entity.ProjectId,
        };
    }
}
