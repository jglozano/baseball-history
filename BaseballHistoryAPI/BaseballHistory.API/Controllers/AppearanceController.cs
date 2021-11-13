using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseballHistory.Domain.Entities;
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

    public AppearanceController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<AppearanceController> logger)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Appearance>>> Get()
    {
        try
        {
            return new ObjectResult(await _supervisor.GetAppearance());
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
}