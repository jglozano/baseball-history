using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagerController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ManagerController> _logger;
    private readonly IUriService _uriService;

    public ManagerController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ManagerController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Manager>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetManager(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetManagerCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagerController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, inseason
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{inseason}", Name = "GetManagerById")]
    public async Task<ActionResult<Manager>> Get(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        try
        {
            var entity = await _supervisor.GetManagerById(playerId, teamId, yearId, lgId, inseason);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ManagerController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}