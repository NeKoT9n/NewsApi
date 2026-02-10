using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApi.DataAccess.Entities;

namespace NewsApi.DataAccess.Configuration;

public class NewsConfiguration : IEntityTypeConfiguration<NewsEntity>
{
    public void Configure(EntityTypeBuilder<NewsEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.News)
            .UsingEntity(j => j.ToTable("NewsCategories"));
        
        builder
            .HasMany(x => x.Ratings)
            .WithOne(x => x.News)
            .HasForeignKey(x => x.NewsId);

        builder
            .HasOne(x => x.Sentiment)
            .WithOne(x => x.News)
            .HasForeignKey<SentimentEntity>(x => x.NewsId);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.PublishedAt).IsRequired();
    }
    
}