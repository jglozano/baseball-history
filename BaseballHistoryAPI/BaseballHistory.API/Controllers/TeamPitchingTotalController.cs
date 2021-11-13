using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamPitchingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamPitchingTotalController> _logger;

    public TeamPitchingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamPitchingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamPitchingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetTeamPitchingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamPitchingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamPitchingTotalById")]
    public async Task<ActionResult<TeamPitchingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamPitchingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamPitchingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}