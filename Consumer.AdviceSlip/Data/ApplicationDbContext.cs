namespace Consumer.AdviceSlip.Data;

using Consumer.AdviceSlip.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Slip> Slip { get; set; }
}