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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReasonCreateDto reason)
    {
        await _service.Add(reason);
        return Ok();
    }
}