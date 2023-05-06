namespace Application.Projects.Queries;

public class ProjectDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Bpm { get; set; }
    public string? TimeSig { get; set; }
}
