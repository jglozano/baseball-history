using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SchoolController> _logger;
    private readonly IUriService _uriService;

    public SchoolController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SchoolController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<School>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetSchool(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetSchoolCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
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