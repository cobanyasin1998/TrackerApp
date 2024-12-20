using CoreBase.Identity.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.DbContexts;

public sealed class IdentityDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> UserEntities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
