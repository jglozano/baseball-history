using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingPostController> _logger;

    public FieldingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingPostController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<FieldingPost>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetFieldingPost());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round, pos
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{round}/{pos}", Name = "GetFieldingPostById")]
    public async Task<ActionResult<FieldingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        try
        {
            var entity = await _supervisor.GetFieldingPostById(playerId, teamId, yearId, lgId, round, pos);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}