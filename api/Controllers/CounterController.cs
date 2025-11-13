using application.DTOs;
using application.Interfaces.Services;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/counter")]
public class CounterController : ControllerBase
{
    private readonly ICounterService _service;

    public CounterController(ICounterService service)
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

    [HttpGet("with-count")]
    public async Task<IActionResult> GetCountersWithCount()
    {
        var dto = await _service.GetCounterWithCount();
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpGet("with-count/{id}")]
    public async Task<IActionResult> GetCounterWithCount(int id)
    {
        var dto = await _service.GetCounterWithCount(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CounterCreateDto counter)
    {
        await _service.Add(counter);
        return Ok();
    }
}