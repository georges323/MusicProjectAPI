using Application.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

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
    [ProducesResponseType(typeof(List<ProjectDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
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
}
