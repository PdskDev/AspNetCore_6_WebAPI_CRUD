using WebApiTuto.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiTuto.Data;

public class CurrentDbContext : DbContext
{
    public CurrentDbContext(DbContextOptions<CurrentDbContext> options): base (options)
    {

    }
    public DbSet<Cake> Cake {get; set;}
        
}
