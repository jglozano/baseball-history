using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<BattingController> _logger;
    private readonly IUriService _uriService;

    public BattingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<BattingController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Batting>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetBatting(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetBattingCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}", Name = "GetBattingById")]
    public async Task<ActionResult<Batting>> Get(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        try
        {
            var entity = await _supervisor.GetBattingById(playerId, teamId, yearId, lgId, stint);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}