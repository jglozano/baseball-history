using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingController> _logger;
    private readonly IUriService _uriService;

    public FieldingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }
    
    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Fielding>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetFielding(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetFieldingCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint, pos
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}/{pos}", Name = "GetFieldingById")]
    public async Task<ActionResult<Fielding>> Get(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        try
        {
            var entity = await _supervisor.GetFieldingById(playerId, teamId, yearId, lgId, stint, pos);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}