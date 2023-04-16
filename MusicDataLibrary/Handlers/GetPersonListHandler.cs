using MediatR;
using MusicDataLibrary.DataAccess;
using MusicDataLibrary.Models;
using MusicDataLibrary.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLibrary.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetProjectListQuery, List<ProjectModel>>
    {
        private readonly IMusicDataAccess _data;

        public GetPersonListHandler(IMusicDataAccess data)
        {
            _data = data;
        }

        public Task<List<ProjectModel>> Handle(GetProjectListQuery request, CancellationToken cancellationToken) 
        {
            return Task.FromResult(_data.GetProjects());
        }
    }
}
