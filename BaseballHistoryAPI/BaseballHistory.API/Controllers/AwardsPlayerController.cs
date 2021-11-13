using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsPlayerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AwardsPlayerController> _logger;

    public AwardsPlayerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AwardsPlayerController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AwardsPlayer>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAwardsPlayer());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsPlayerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, awardId
    [HttpGet("{playerId}/{yearId}/{lgId}/{awardId}", Name = "GetAwardsPlayerById")]
    public async Task<ActionResult<AwardsPlayer>> Get(string playerId, short yearId, string lgId, string awardId)
    {
        try
        {
            var entity = await _supervisor.GetAwardsPlayerById(playerId, yearId, lgId, awardId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsPlayerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}