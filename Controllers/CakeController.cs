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
        
}
