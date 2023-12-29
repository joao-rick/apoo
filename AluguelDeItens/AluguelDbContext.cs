using Microsoft.EntityFrameworkCore;

public class AluguelDbContext : DbContext
{
    public AluguelDbContext(DbContextOptions<AluguelDbContext> options) : base(options)
    {
    }

    public DbSet<ItemAluguel> ItensAluguel { get; set; }
}
