using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamPitchingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamPitchingTotalController> _logger;
    private readonly IUriService _uriService;

    public TeamPitchingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamPitchingTotalController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<TeamPitchingTotal>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetTeamPitchingTotal(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetTeamPitchingTotalCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamPitchingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamPitchingTotalById")]
    public async Task<ActionResult<TeamPitchingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamPitchingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamPitchingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // teamId
    [HttpGet("{teamId}", Name = "GetTeamPitchingTotalByTeamId")]
    public async Task<ActionResult<List<TeamPitchingTotal>>> Get(string teamId)
    {
        try
        {
            return Ok(await _supervisor.GetTeamPitchingTotalByTeamId(teamId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamPitchingTotalController GetByTeamId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}