using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApi.DataAccess.Entities;

namespace NewsApi.DataAccess.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.News)
            .WithMany(x => x.Categories);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);

        List<CategoryEntity> categoriesByDefault =
        [
            new CategoryEntity() { Id = 1 , Name = "Sport" },
            new CategoryEntity() { Id = 2 , Name = "Business" },
            new CategoryEntity() { Id = 3 , Name = "Technology" }
        ]; //TODO: to appsettings.json

        builder.HasData(categoriesByDefault);
    }
}