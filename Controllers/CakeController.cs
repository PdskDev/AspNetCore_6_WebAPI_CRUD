using WebApiTuto.Data;
using WebApiTuto.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiTuto.Controllers;

[ApiController]
[Route("[controller]")]
public class CakeController: ControllerBase
{
    private readonly CurrentDbContext _currentDbContext;
    public CakeController(CurrentDbContext currentDbContext)
    {
        _currentDbContext = currentDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var cakes = await _currentDbContext.Cake.ToListAsync();
        return Ok(cakes);
    }

    [HttpGet]
    [Route("get-cake-by-id")]
    public async Task<IActionResult> GetCakeByIdAsync(int id)
    {
        var cake = await _currentDbContext.Cake.FindAsync(id);
        return Ok(cake);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Cake cake)
    {
        _currentDbContext.Cake.Add(cake);
        await _currentDbContext.SaveChangesAsync();
        return Created($"/get-cake-by-id?id={cake.Id}", cake);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Cake cakeToUpdate)
    {
        _currentDbContext.Cake.Update(cakeToUpdate);
        await _currentDbContext.SaveChangesAsync();
        return NoContent();
    }
        
}
