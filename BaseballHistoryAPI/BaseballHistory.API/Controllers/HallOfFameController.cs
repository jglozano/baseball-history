using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HallOfFameController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<HallOfFameController> _logger;
    private readonly IUriService _uriService;

    public HallOfFameController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<HallOfFameController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<HallOfFame>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetHallOfFame(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetHallOfFameCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HallOfFameController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, votedBy
    [HttpGet("{playerId}/{yearId}/{votedBy}", Name = "GetHallOfFameById")]
    public async Task<ActionResult<HallOfFame>> Get(string playerId, short yearId, string votedBy)
    {
        try
        {
            var entity = await _supervisor.GetHallOfFameById(playerId, yearId, votedBy);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HallOfFameController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}