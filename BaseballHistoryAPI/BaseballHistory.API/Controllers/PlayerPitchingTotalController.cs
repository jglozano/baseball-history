using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerPitchingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PlayerPitchingTotalController> _logger;

    public PlayerPitchingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PlayerPitchingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlayerPitchingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPlayerPitchingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerPitchingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPlayerPitchingTotalById")]
    public async Task<ActionResult<PlayerPitchingTotal>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPlayerPitchingTotalById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerPitchingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}