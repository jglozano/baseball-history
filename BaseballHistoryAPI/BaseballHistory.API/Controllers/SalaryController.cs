using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SalaryController> _logger;

    public SalaryController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SalaryController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Salary>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetSalary());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SalaryController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}", Name = "GetSalaryById")]
    public async Task<ActionResult<Salary>> Get(string playerId, string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetSalaryById(playerId, teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SalaryController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}