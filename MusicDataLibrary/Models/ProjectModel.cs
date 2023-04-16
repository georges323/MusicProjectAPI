using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Bpm { get; set; }
        public string? TimeSig { get; set; }
    }
}
