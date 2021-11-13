using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerBattingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PlayerBattingTotalController> _logger;

    public PlayerBattingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PlayerBattingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlayerBattingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPlayerBattingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerBattingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPlayerBattingTotalById")]
    public async Task<ActionResult<PlayerBattingTotal>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPlayerBattingTotalById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerBattingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}