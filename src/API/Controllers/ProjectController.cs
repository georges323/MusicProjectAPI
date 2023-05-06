using Application.Projects.Queries;
using MediatR;
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
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProjectsQuery());

        return Ok(result);
    }

    // GET: api/<ProjectController>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProjectQuery(id));

        if (result == null)
        {
            return BadRequest("Project not found.");
        }

        return Ok(result);
    }
}
