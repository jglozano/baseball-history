using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsShareManagerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AwardsShareManagerController> _logger;

    public AwardsShareManagerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AwardsShareManagerController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AwardsShareManager>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAwardsShareManager());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsShareManagerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, awardId
    [HttpGet("{playerId}/{yearId}/{lgId}/{awardId}", Name = "GetAwardsShareManagerById")]
    public async Task<ActionResult<AwardsShareManager>> Get(string playerId, short yearId, string lgId, string awardId)
    {
        try
        {
            var entity = await _supervisor.GetAwardsShareManagerById(playerId, yearId, lgId, awardId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsShareManagerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}