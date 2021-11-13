using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagersHalfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ManagersHalfController> _logger;

    public ManagersHalfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ManagersHalfController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<ManagersHalf>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetManagersHalf());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagersHalfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, inseason, half
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{inseason}/{half}", Name = "GetManagersHalfById")]
    public async Task<ActionResult<ManagersHalf>> Get(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        try
        {
            var entity = await _supervisor.GetManagersHalfById(playerId, teamId, yearId, lgId, inseason, half);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagersHalfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}