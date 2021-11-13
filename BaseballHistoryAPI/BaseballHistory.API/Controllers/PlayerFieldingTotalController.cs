using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerFieldingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PlayerFieldingTotalController> _logger;

    public PlayerFieldingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PlayerFieldingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlayerFieldingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPlayerFieldingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerFieldingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPlayerFieldingTotalById")]
    public async Task<ActionResult<PlayerFieldingTotal>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPlayerFieldingTotalById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerFieldingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}