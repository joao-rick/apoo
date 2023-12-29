using System.Data.Entity;
using System.Models;

public class AluguelDbContext : DbContext
{
    public AluguelDbContext(DbContextOptions<AluguelDbContext> options) : base(options)
    {
    }

    public DbSet<ItemAluguel> ItensAluguel { get; set; }
}
