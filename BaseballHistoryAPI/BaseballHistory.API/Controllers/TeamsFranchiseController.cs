using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsFranchiseController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamsFranchiseController> _logger;

    public TeamsFranchiseController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamsFranchiseController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamsFranchise>>> Get()
    {
        try
        {
            var entities = await _supervisor.GetTeamsFranchise();
            return new ObjectResult(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsFranchiseController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // franchId
    [HttpGet("{franchId}", Name = "GetTeamsFranchiseById")]
    public async Task<ActionResult<TeamsFranchise>> Get(string franchId)
    {
        try
        {
            var entity = await _supervisor.GetTeamsFranchiseById(franchId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsFranchiseController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}