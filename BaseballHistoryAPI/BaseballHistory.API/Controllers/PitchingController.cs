using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PitchingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PitchingController> _logger;
    private readonly IUriService _uriService;

    public PitchingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PitchingController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Pitching>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetPitching(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetPitchingCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, stint
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{stint}", Name = "GetPitchingById")]
    public async Task<ActionResult<Pitching>> Get(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        try
        {
            var entity = await _supervisor.GetPitchingById(playerId, teamId, yearId, lgId, stint);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}