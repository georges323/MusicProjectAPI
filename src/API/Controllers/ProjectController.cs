using Application.Projects.Commands;
using Application.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiException]
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
    [ProducesResponseType(typeof(List<ProjectDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        // Will be used
        var sub = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

        var result = await _mediator.Send(new GetProjectsQuery());

        if (!result.Any())
        {
            return NotFound("Projects Not Found");
        }

        return Ok(result);
    }

    // GET: api/<ProjectController>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProjectQuery(id));

        if (result == null)
        {
            return NotFound("Project not found.");
        }

        return Ok(result);
    }

    // POST: api/<ProjectController>
    [HttpPost]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IDictionary<string,string[]>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateProjectCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
