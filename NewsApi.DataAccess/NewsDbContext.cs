using Microsoft.EntityFrameworkCore;
using NewsApi.DataAccess.Entities;
using NewsApi.Domain.Models;

namespace NewsApi.DataAccess;

public class NewsDbContext(DbContextOptions<NewsDbContext> options) : DbContext(options)
{
    public DbSet<NewsEntity> News => Set<NewsEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<SentimentType>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewsDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}