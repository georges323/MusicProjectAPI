using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Projects.Commands
{
    public record CreateProjectCommand(string Name, int Bpm, string TimeSig) : IRequest<Project>;

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TimeSig = request.TimeSig,
                Bpm = request.Bpm
            };

            _context.Projects.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
