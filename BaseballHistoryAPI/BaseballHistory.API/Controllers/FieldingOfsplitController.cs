using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingOfsplitController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingOfsplitController> _logger;

    public FieldingOfsplitController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingOfsplitController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<FieldingOfsplit>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetFieldingOfsplit());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfsplitController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint, pos
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}/{pos}", Name = "GetFieldingOfsplitById")]
    public async Task<ActionResult<FieldingOfsplit>> Get(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        try
        {
            var entity = await _supervisor.GetFieldingOfsplitById(playerId, teamId, yearId, lgId, stint, pos);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfsplitController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}