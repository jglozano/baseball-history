using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ParkController> _logger;

    public ParkController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ParkController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Park>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetPark());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ParkController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // parkId
    [HttpGet("{parkId}", Name = "GetParkById")]
    public async Task<ActionResult<Park>> Get(string parkId)
    {
        try
        {
            var entity = await _supervisor.GetParkById(parkId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ParkController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}