using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<SalaryController> _logger;
    private readonly IUriService _uriService;

    public SalaryController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<SalaryController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Salary>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetSalary(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetSalaryCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SalaryController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}", Name = "GetSalaryById")]
    public async Task<ActionResult<Salary>> Get(string playerId, string teamId, short yearId, string lgId)
    {
        try
        {
            var entity = await _supervisor.GetSalaryById(playerId, teamId, yearId, lgId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SalaryController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetSalaryByPlayerId")]
    public async Task<ActionResult<List<Salary>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetSalaryByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the SalaryController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}