using HouseDemo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseDemo.DataAccess.EntityContext;

public class HouseDbContext : DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
    }
}


