using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamBattingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamBattingTotalController> _logger;

    public TeamBattingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamBattingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamBattingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetTeamBattingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamBattingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamBattingTotalById")]
    public async Task<ActionResult<TeamBattingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamBattingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamBattingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}