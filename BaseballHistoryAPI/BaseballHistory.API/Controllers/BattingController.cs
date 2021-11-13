using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<BattingController> _logger;

    public BattingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<BattingController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Batting>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetBatting());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}", Name = "GetBattingById")]
    public async Task<ActionResult<Batting>> Get(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        try
        {
            var entity = await _supervisor.GetBattingById(playerId, teamId, yearId, lgId, stint);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}