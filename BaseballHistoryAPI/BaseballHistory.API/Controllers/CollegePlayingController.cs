using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollegePlayingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<CollegePlayingController> _logger;

    public CollegePlayingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<CollegePlayingController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<CollegePlaying>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetCollegePlaying());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the CollegePlayingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, schoolId
    [HttpGet("{playerId}/{yearId}/{schoolId}", Name = "GetCollegePlayingById")]
    public async Task<ActionResult<CollegePlaying>> Get(string playerId, short yearId, string schoolId)
    {
        try
        {
            var entity = await _supervisor.GetCollegePlayingById(playerId, yearId, schoolId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the CollegePlayingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}