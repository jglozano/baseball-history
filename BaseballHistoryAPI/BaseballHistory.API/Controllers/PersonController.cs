using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PersonController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPerson());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PersonController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPersonById")]
    public async Task<ActionResult<Person>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPersonById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PersonController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}