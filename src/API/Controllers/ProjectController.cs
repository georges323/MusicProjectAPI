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
    public async Task<List<ProjectDto>> Get()
    {
        return await _mediator.Send(new GetProjectsQuery());
    }
}
