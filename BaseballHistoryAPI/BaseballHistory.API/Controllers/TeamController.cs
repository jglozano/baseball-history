using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamController> _logger;

    public TeamController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Team>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetTeam());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamById")]
    public async Task<ActionResult<Team>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}