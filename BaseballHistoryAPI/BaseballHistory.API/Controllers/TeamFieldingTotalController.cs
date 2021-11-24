using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamFieldingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamFieldingTotalController> _logger;
    private readonly IUriService _uriService;

    public TeamFieldingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamFieldingTotalController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<TeamFieldingTotal>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetTeamFieldingTotal(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetTeamFieldingTotalCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamFieldingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamFieldingTotalById")]
    public async Task<ActionResult<TeamFieldingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamFieldingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamFieldingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // teamId
    [HttpGet("{teamId}", Name = "GetTeamFieldingTotalByTeamId")]
    public async Task<ActionResult<List<TeamFieldingTotal>>> Get(string teamId)
    {
        try
        {
            return Ok(await _supervisor.GetTeamFieldingTotalByTeamId(teamId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamFieldingTotalController GetByTeamId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}