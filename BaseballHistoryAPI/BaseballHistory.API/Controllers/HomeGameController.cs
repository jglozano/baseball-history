using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeGameController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<HomeGameController> _logger;

    public HomeGameController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<HomeGameController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<HomeGame>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetHomeGame());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HomeGameController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, lgId, yearId, parkId
    [HttpGet("{teamId}/{lgId}/{yearId}/{parkId}", Name = "GetHomeGameById")]
    public async Task<ActionResult<HomeGame>> Get(string teamId, string lgId, short yearId, string parkId)
    {
        try
        {
            var entity = await _supervisor.GetHomeGameById(teamId, lgId, yearId, parkId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HomeGameController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}