using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SchoolController> _logger;

    public SchoolController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SchoolController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<School>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetSchool());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SchoolController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // schoolId
    [HttpGet("{schoolId}", Name = "GetSchoolById")]
    public async Task<ActionResult<School>> Get(string schoolId)
    {
        try
        {
            var entity = await _supervisor.GetSchoolById(schoolId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SchoolController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}