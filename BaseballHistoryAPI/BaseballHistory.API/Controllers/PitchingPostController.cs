using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PitchingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PitchingPostController> _logger;
    private readonly IUriService _uriService;

    public PitchingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PitchingPostController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<PitchingPost>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetPitchingPost(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetPitchingPostCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{round}", Name = "GetPitchingPostById")]
    public async Task<ActionResult<PitchingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round)
    {
        try
        {
            var entity = await _supervisor.GetPitchingPostById(playerId, teamId, yearId, lgId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetPitchingPostByPlayerId")]
    public async Task<ActionResult<List<Appearance>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetPitchingPostByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PitchingPostController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}