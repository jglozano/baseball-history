using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsFranchiseController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<TeamsFranchiseController> _logger;
    private readonly IUriService _uriService;

    public TeamsFranchiseController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<TeamsFranchiseController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<TeamsFranchise>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetTeamsFranchise(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetTeamsFranchiseCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsFranchiseController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // franchId
    [HttpGet("{franchId}", Name = "GetTeamsFranchiseById")]
    public async Task<ActionResult<TeamsFranchise>> Get(string franchId)
    {
        try
        {
            var entity = await _supervisor.GetTeamsFranchiseById(franchId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the TeamsFranchiseController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}