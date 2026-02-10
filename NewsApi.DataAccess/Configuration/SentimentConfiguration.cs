using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApi.DataAccess.Entities;

namespace NewsApi.DataAccess.Configuration;

public class SentimentConfiguration : IEntityTypeConfiguration<SentimentEntity>
{
    public void Configure(EntityTypeBuilder<SentimentEntity> builder)
    {
        builder.HasKey(x => x.NewsId);
            
        builder
            .Property(x => x.Score)
            .IsRequired();
            
        builder
            .Property(x => x.Type)
            .IsRequired()
            .HasColumnType("sentiment_type");
    }
}