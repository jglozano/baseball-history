using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsSharePlayerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AwardsSharePlayerController> _logger;

    public AwardsSharePlayerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AwardsSharePlayerController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AwardsSharePlayer>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAwardsSharePlayer());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsSharePlayerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, awardId
    [HttpGet("{playerId}/{yearId}/{lgId}/{awardId}", Name = "GetAwardsSharePlayerById")]
    public async Task<ActionResult<AwardsSharePlayer>> Get(string playerId, short yearId, string lgId, string awardId)
    {
        try
        {
            var entity = await _supervisor.GetAwardsSharePlayerById(playerId, yearId, lgId, awardId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsSharePlayerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}