using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HallOfFameController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<HallOfFameController> _logger;

    public HallOfFameController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<HallOfFameController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<HallOfFame>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetHallOfFame());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HallOfFameController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, votedBy
    [HttpGet("{playerId}/{yearId}/{votedBy}", Name = "GetHallOfFameById")]
    public async Task<ActionResult<HallOfFame>> Get(string playerId, short yearId, string votedBy)
    {
        try
        {
            var entity = await _supervisor.GetHallOfFameById(playerId, yearId, votedBy);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HallOfFameController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}