using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PitchingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PitchingPostController> _logger;

    public PitchingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PitchingPostController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PitchingPost>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPitchingPost());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{round}", Name = "GetPitchingPostById")]
    public async Task<ActionResult<PitchingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round)
    {
        try
        {
            var entity = await _supervisor.GetPitchingPostById(playerId, teamId, yearId, lgId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}