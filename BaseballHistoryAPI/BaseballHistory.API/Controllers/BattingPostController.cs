using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<BattingPostController> _logger;
    private readonly IUriService _uriService;

    public BattingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<BattingPostController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<BattingPost>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetBattingPost(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetBattingPostCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round
    [HttpGet("{playerId}/{teamId}/{lgId}/{round}", Name = "GetBattingPostById")]
    public async Task<ActionResult<BattingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round)
    {
        try
        {
            var entity = await _supervisor.GetBattingPostById(playerId, teamId, yearId, lgId, round);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetBattingPostByPlayerId")]
    public async Task<ActionResult<List<BattingPost>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetBattingPostByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the BattingPostController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}