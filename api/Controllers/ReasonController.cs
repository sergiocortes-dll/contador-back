using application.DTOs;
using application.Interfaces.Services;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/reason")]
public class ReasonController : ControllerBase
{
    private readonly IReasonService _service;

    public ReasonController(IReasonService service)
    {
        _service = service;
    }
    
    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAll());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var  counter = await _service.GetById(id);
        if (counter == null)
            return NotFound();
        
        return Ok(counter);
    }

    [HttpGet("by-counter/{id}")]
    public async Task<IActionResult> GetByCounter(int id)
    {
        var reasons = await _service.GetByCounter(id);
        if (reasons == null)
            return NotFound();
        return Ok(reasons);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReasonCreateDto reason)
    {
        var created = await _service.Add(reason);
        return CreatedAtAction(nameof(Post), new { id = created.Id }, created);
    }

    [HttpPost("increment/{reasonId}/{counterId}")]
    public async Task<IActionResult> IncrementReasonCount(int reasonId, int counterId)
    {
        var result = await _service.IncrementCount(reasonId, counterId);

        if (!result)
            return NotFound($"Reason with ID {reasonId} not found");

        return Ok(new { message = "Count incremented successfully" });
    }
}