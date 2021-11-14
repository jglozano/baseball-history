using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollegePlayingController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<CollegePlayingController> _logger;
    private readonly IUriService _uriService;

    public CollegePlayingController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<CollegePlayingController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<CollegePlaying>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetCollegePlaying(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetCollegePlayingCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the CollegePlayingController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId, yearId, schoolId
    [HttpGet("{playerId}/{yearId}/{schoolId}", Name = "GetCollegePlayingById")]
    public async Task<ActionResult<CollegePlaying>> Get(string playerId, short yearId, string schoolId)
    {
        try
        {
            var entity = await _supervisor.GetCollegePlayingById(playerId, yearId, schoolId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the CollegePlayingController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}