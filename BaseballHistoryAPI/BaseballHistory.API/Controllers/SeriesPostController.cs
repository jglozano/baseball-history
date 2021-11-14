using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SeriesPostController> _logger;
    private readonly IUriService _uriService;

    public SeriesPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SeriesPostController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<SeriesPost>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetSeriesPost(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetSeriesPostCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SeriesPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamIdwinner, lgIdwinner, yearId, round
    [HttpGet("{teamIdwinner}/{lgIdwinner}/{yearId}/{round}", Name = "GetSeriesPostById")]
    public async Task<ActionResult<SeriesPost>> Get(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        try
        {
            var entity = await _supervisor.GetSeriesPostById(teamIdwinner, lgIdwinner, yearId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SeriesPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}