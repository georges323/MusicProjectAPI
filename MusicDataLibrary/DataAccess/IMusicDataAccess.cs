using MusicDataLibrary.Models;

namespace MusicDataLibrary.DataAccess
{
    public interface IMusicDataAccess
    {
        ProjectModel AddProject(string name, int bpm, string timeSig);
        List<ProjectModel> GetProjects();
    }
}