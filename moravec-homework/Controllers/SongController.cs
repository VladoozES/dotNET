using Project.Startup.Features.Song;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.Startup.Controllers;

public class SongController : Controller
{
    private readonly ILogger<SongController> _logger;
    private readonly IMediator _mediator;

    public SongController(ILogger<SongController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("~/getSong")]
    public async Task<IActionResult> CreateNewSong(GetSongQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("~/createNewSong")]
    public async Task<IActionResult> CreateNewSong(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateNewSongCommand(), cancellationToken);
        return Ok();
    }

}