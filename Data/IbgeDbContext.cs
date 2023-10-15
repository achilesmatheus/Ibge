using IbgeApi.Data.FluentMapping;
using IbgeApi.Models;

namespace IbgeApi.Data;
using Microsoft.EntityFrameworkCore;

public class IbgeDbContext : DbContext
{
    public IbgeDbContext(DbContextOptions<IbgeDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}