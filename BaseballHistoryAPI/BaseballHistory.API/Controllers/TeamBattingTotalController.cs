using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamBattingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamBattingTotalController> _logger;
    private readonly IUriService _uriService;

    public TeamBattingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamBattingTotalController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<TeamBattingTotal>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetTeamBattingTotal(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetTeamBattingTotalCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamBattingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// teamId, yearId, lgId
    [HttpGet("{teamId}/{yearId}/{lgId}", Name = "GetTeamBattingTotalById")]
    public async Task<ActionResult<TeamBattingTotal>> Get(string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetTeamBattingTotalById(teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamBattingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}