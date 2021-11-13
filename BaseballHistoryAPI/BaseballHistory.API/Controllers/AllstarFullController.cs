using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllstarFullController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AllstarFullController> _logger;

    public AllstarFullController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AllstarFullController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AllstarFull>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAllstarFull());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AllstarFullController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, lgId, yearId, gameId
    [HttpGet("{playerId}/{teamId}/{lgId}/{gameId}", Name = "GetAllstarFullById")]
    public async Task<ActionResult<AllstarFull>> Get(string playerId, string teamId, string lgId, short yearId,
        string gameId)
    {
        try
        {
            var entity = await _supervisor.GetAllstarFullById(playerId, teamId, lgId, yearId, gameId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AllstarFullController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}