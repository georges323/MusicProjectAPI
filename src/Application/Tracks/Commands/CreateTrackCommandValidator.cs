using FluentValidation;

namespace Application.Tracks.Commands;

public class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
{
    public CreateTrackCommandValidator()
    {
        RuleFor(v => v.File.ContentType)
            .Must(x => x.Equals("audio/wav")).WithMessage("File type must be audio/wav.");

        RuleFor(v => v.File.Length)
            .NotNull().WithMessage("Must upload a file.");

        RuleFor(v => v.File.FileName)
            .NotNull().WithMessage("Must have a name.");
    }
}
 
