using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsManagerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AwardsManagerController> _logger;
    private readonly IUriService _uriService;

    public AwardsManagerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AwardsManagerController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<AwardsManager>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetAwardsManager(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetAwardsManagerCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsManagerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, awardId
    [HttpGet("{playerId}/{teamId}/{lgId}/{gameId}", Name = "GetAwardsManagerById")]
    public async Task<ActionResult<AwardsManager>> Get(string playerId, short yearId, string lgId, string awardId)
    {
        try
        {
            var entity = await _supervisor.GetAwardsManagerById(playerId, yearId, lgId, awardId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AwardsManagerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}