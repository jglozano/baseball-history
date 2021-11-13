using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingController> _logger;

    public FieldingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Fielding>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetFielding());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint, pos
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}/{pos}", Name = "GetFieldingById")]
    public async Task<ActionResult<Fielding>> Get(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        try
        {
            var entity = await _supervisor.GetFieldingById(playerId, teamId, yearId, lgId, stint, pos);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}