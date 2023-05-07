using FluentValidation;

namespace Application.Projects.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(v => v.Bpm)
            .LessThan(300).WithMessage("BPM must be less than 300")
            .GreaterThan(1).WithMessage("BPM must be more than 1");
    }
}
