using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ManagerController> _logger;

    public ManagerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ManagerController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Manager>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetManager());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, inseason
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{inseason}", Name = "GetManagerById")]
    public async Task<ActionResult<Manager>> Get(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        try
        {
            var entity = await _supervisor.GetManagerById(playerId, teamId, yearId, lgId, inseason);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}