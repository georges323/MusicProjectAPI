using Application.Tracks.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiException]
[ApiController]
public class TrackController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrackController(IMediator mediator)
    {
        _mediator = mediator;    
    }

    // GET: api/<TrackController>
    [HttpGet("{projectId}")]
    [ProducesResponseType(typeof(List<TrackDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid projectId)
    {
        var result = await _mediator.Send(new GetTracksQuery(projectId));

        if (!result.Any())
        {
            return NotFound("Tracks not found.");
        }

        return Ok(result);
    }
}
