using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsHalfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamsHalfController> _logger;

    public TeamsHalfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamsHalfController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamsHalf>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetTeamsHalf());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsHalfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, yearId, lgId, half
    [HttpGet("{teamId}/{yearId}/{lgId}/{half}", Name = "GetTeamsHalfById")]
    public async Task<ActionResult<TeamsHalf>> Get(string teamId, short yearId, string lgId, string half)
    {
        try
        {
            var entity = await _supervisor.GetTeamsHalfById(teamId, yearId, lgId, half);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsHalfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}