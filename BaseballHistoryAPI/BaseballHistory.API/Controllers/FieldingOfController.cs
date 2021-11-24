using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingOfController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingOfController> _logger;
    private readonly IUriService _uriService;

    public FieldingOfController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingOfController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<FieldingOf>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetFieldingOf(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetFieldingOfCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, stint
    [HttpGet("{playerId}/{yearId}/{stint}", Name = "GetFieldingOfById")]
    public async Task<ActionResult<FieldingOf>> Get(string playerId, short yearId, short stint)
    {
        try
        {
            var entity = await _supervisor.GetFieldingOfById(playerId, yearId, stint);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetFieldingOfByPlayerId")]
    public async Task<ActionResult<List<FieldingOf>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetFieldingOfByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingOfController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}