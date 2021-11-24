using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppearanceController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<AppearanceController> _logger;
    private readonly IUriService _uriService;

    public AppearanceController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AppearanceController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }
    
    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Appearance>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetAppearance(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetAppearanceCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AppearanceController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, lgId, teamId
    [HttpGet("{playerId}/{yearId}/{lgId}/{teamId}", Name = "GetAppearanceById")]
    public async Task<ActionResult<Appearance>> Get(string playerId, short yearId, string lgId, string teamId)
    {
        try
        {
            var entity = await _supervisor.GetAppearanceById(playerId, yearId, lgId, teamId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AppearanceController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // playerId
    [HttpGet("{playerId}", Name = "GetAppearanceByPlayerId")]
    public async Task<ActionResult<List<Appearance>>> Get(string playerId)
    {
        try
        {
            return Ok(await _supervisor.GetAppearanceByPlayerId(playerId));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the AppearanceController GetByPlayerId action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}