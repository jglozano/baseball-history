using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingOfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingOfController> _logger;

    public FieldingOfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingOfController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<FieldingOf>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetFieldingOf());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, stint
    [HttpGet("{playerId}/{yearId}/{stint}", Name = "GetFieldingOfById")]
    public async Task<ActionResult<FieldingOf>> Get(string playerId, short yearId, short stint)
    {
        try
        {
            var entity = await _supervisor.GetFieldingOfById(playerId, yearId, stint);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}