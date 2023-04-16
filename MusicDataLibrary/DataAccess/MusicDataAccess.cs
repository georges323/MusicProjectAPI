using MusicDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLibrary.DataAccess
{
    public class MusicDataAccess : IMusicDataAccess
    {
        private List<ProjectModel> projects = new();

        public MusicDataAccess()
        {
            projects.Add(new ProjectModel { Id = 1, Name = "Drowning", Bpm = 140, TimeSig = "4/4" });
            projects.Add(new ProjectModel { Id = 2, Name = "Wilson Ave.", Bpm = 175, TimeSig = "4/4" });
        }

        public List<ProjectModel> GetProjects()
        {
            return projects;
        }

        public ProjectModel AddProject(string name, int bpm, string timeSig)
        {
            ProjectModel project = new() { Name = name, Bpm = bpm, TimeSig = timeSig };
            project.Id = projects.Max(x => x.Id) + 1;
            projects.Add(project);
            return project;
        }
    }
}
