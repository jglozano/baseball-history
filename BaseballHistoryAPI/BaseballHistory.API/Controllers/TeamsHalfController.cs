using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsHalfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamsHalfController> _logger;
    private readonly IUriService _uriService;

    public TeamsHalfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamsHalfController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<TeamsHalf>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetTeamsHalf(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetTeamsHalfCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsHalfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, yearId, lgId, half
    [HttpGet("{teamId}/{yearId}/{lgId}/{half}", Name = "GetTeamsHalfById")]
    public async Task<ActionResult<TeamsHalf>> Get(string teamId, short yearId, string lgId, string half)
    {
        try
        {
            var entity = await _supervisor.GetTeamsHalfById(teamId, yearId, lgId, half);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsHalfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}