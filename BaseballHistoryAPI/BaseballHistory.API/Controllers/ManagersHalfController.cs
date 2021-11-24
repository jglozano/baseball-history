using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagersHalfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ManagersHalfController> _logger;
    private readonly IUriService _uriService;

    public ManagersHalfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ManagersHalfController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<ManagersHalf>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetManagersHalf(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetManagersHalfCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagersHalfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, inseason, half
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{inseason}/{half}", Name = "GetManagersHalfById")]
    public async Task<ActionResult<ManagersHalf>> Get(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        try
        {
            var entity = await _supervisor.GetManagersHalfById(playerId, teamId, yearId, lgId, inseason, half);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagersHalfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetManagersHalfByPlayerId")]
    public async Task<ActionResult<List<ManagersHalf>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetManagersHalfByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagersHalfController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}