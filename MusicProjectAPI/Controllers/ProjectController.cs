using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicDataLibrary.Models;
using MusicDataLibrary.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<List<ProjectModel>> Get()
        {
            return await _mediator.Send(new GetProjectListQuery());
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
