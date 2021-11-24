using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Filters;
using BaseballHistory.Domain.Helpers;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BaseballHistory.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IBaseballHistorySupervisor _supervisor;
    private readonly ILogger<PersonController> _logger;
    private readonly IUriService _uriService;

    public PersonController(IBaseballHistorySupervisor baseballHistorySupervisor,
        ILogger<PersonController> logger, IUriService uriService)
    {
        _supervisor = baseballHistorySupervisor;
        _logger = logger;
        _uriService = uriService;
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<List<Person>>> Get(int pageNumber, int pageSize)
    {
        try
        {
            var route = Request.Path.Value!;
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _supervisor.GetPerson(pageNumber, pageSize);
            var totalRecords = await _supervisor.GetPersonCount();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);
            return new ObjectResult(pagedReponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PersonController Get action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }

    // playerId
    [HttpGet("{playerId}", Name = "GetPersonById")]
    public async Task<ActionResult<Person>> Get(string playerId)
    {
        try
        {
            var entity = await _supervisor.GetPersonById(playerId);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PersonController GetById action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
    
    // lastName
    [HttpGet("{lastName}", Name = "GetPersonByLastName")]
    public async Task<ActionResult<List<Person>>> GetByLastName(string lastName)
    {
        try
        {
            return Ok(await _supervisor.GetPersonByLastName(lastName));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the PersonController GetByLastName action: {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}