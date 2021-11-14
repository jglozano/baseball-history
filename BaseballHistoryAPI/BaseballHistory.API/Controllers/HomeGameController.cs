using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeGameController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<HomeGameController> _logger;
    private readonly IUriService _uriService;

    public HomeGameController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<HomeGameController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<HomeGame>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetHomeGame(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetHomeGameCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HomeGameController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // teamId, lgId, yearId, parkId
    [HttpGet("{teamId}/{lgId}/{yearId}/{parkId}", Name = "GetHomeGameById")]
    public async Task<ActionResult<HomeGame>> Get(string teamId, string lgId, short yearId, string parkId)
    {
        try
        {
            var entity = await _supervisor.GetHomeGameById(teamId, lgId, yearId, parkId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the HomeGameController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}