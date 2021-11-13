using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SeriesPostController> _logger;

    public SeriesPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SeriesPostController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<SeriesPost>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetSeriesPost());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SeriesPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamIdwinner, lgIdwinner, yearId, round
    [HttpGet("{teamIdwinner}/{lgIdwinner}/{yearId}/{round}", Name = "GetSeriesPostById")]
    public async Task<ActionResult<SeriesPost>> Get(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        try
        {
            var entity = await _supervisor.GetSeriesPostById(teamIdwinner, lgIdwinner, yearId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SeriesPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}