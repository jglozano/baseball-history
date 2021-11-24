using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldingPostController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<FieldingPostController> _logger;
    private readonly IUriService _uriService;

    public FieldingPostController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<FieldingPostController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<FieldingPost>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetFieldingPost(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetFieldingPostCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingPostController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, teamId, yearId, lgId, round, pos
    [HttpGet("{playerId}/{teamId}/{yearId}/{lgId}/{round}/{pos}", Name = "GetFieldingPostById")]
    public async Task<ActionResult<FieldingPost>> Get(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        try
        {
            var entity = await _supervisor.GetFieldingPostById(playerId, teamId, yearId, lgId, round, pos);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingPostController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetFieldingPostByPlayerId")]
    public async Task<ActionResult<List<FieldingPost>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetFieldingPostByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the FieldingPostController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}