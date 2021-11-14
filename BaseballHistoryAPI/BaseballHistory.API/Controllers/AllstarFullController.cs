using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllstarFullController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AllstarFullController> _logger;
    private readonly IUriService _uriService;

    public AllstarFullController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AllstarFullController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<AllstarFull>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetAllstarFull(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetAllStarCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AllstarFullController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, lgId, yearId, gameId
    [HttpGet("{playerId}/{teamId}/{lgId}/{gameId}", Name = "GetAllstarFullById")]
    public async Task<ActionResult<AllstarFull>> Get(string playerId, string teamId, string lgId, short yearId,
        string gameId)
    {
        try
        {
            var entity = await _supervisor.GetAllstarFullById(playerId, teamId, lgId, yearId, gameId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AllstarFullController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}