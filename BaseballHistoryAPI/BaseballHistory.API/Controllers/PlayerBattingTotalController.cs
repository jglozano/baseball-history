using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerBattingTotalController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PlayerBattingTotalController> _logger;
    private readonly IUriService _uriService;

    public PlayerBattingTotalController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PlayerBattingTotalController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<PlayerBattingTotal>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetPlayerBattingTotal(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetPlayerBattingTotalCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerBattingTotalController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPlayerBattingTotalById")]
    public async Task<ActionResult<PlayerBattingTotal>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPlayerBattingTotalById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PlayerBattingTotalController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}