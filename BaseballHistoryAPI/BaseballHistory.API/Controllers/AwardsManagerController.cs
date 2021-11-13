using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsManagerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AwardsManagerController> _logger;

    public AwardsManagerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AwardsManagerController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AwardsManager>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAwardsManager());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsManagerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, awardId
    [HttpGet("{playerId}/{teamId}/{lgId}/{gameId}", Name = "GetAwardsManagerById")]
    public async Task<ActionResult<AwardsManager>> Get(string playerId, short yearId, string lgId, string awardId)
    {
        try
        {
            var entity = await _supervisor.GetAwardsManagerById(playerId, yearId, lgId, awardId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsManagerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}