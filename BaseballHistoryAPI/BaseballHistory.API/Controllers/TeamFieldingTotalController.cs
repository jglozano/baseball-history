using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamFieldingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamFieldingTotalController> _logger;

    public TeamFieldingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamFieldingTotalController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamFieldingTotal>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetTeamFieldingTotal());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamFieldingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamFieldingTotalById")]
    public async Task<ActionResult<TeamFieldingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamFieldingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamFieldingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}