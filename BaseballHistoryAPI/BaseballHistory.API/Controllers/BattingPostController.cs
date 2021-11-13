using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<BattingPostController> _logger;

    public BattingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<BattingPostController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<BattingPost>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetBattingPost());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round
    [HttpGet("{playerId}/{teamId}/{lgId}/{round}", Name = "GetBattingPostById")]
    public async Task<ActionResult<BattingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round)
    {
        try
        {
            var entity = await _supervisor.GetBattingPostById(playerId, teamId, yearId, lgId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}