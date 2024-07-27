using Microsoft.EntityFrameworkCore;
using TradeSet.Core;

namespace TradeSet.Infrastructure;

public class TradeSetDbContext : DbContext
{
    public DbSet<Job> Jobs { get; set; }
    public TradeSetDbContext(DbContextOptions<TradeSetDbContext> options) : base(options)
    {
        
    }
}
