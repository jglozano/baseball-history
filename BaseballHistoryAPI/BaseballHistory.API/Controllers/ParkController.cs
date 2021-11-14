using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<ParkController> _logger;
    private readonly IUriService _uriService;

    public ParkController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<ParkController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Park>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetPark(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetParkCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ParkController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // parkId
    [HttpGet("{parkId}", Name = "GetParkById")]
    public async Task<ActionResult<Park>> Get(string parkId)
    {
        try
        {
            var entity = await _supervisor.GetParkById(parkId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ParkController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}