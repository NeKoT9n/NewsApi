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
            .WithMany(x => x.News);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Content).IsRequired().HasMaxLength(10000);
        builder.Property(x => x.PublishedAt).IsRequired();
        builder.Property(x => x.Sentiment).IsRequired();
        builder.Property(x => x.SentimentScore).IsRequired();
    }
}