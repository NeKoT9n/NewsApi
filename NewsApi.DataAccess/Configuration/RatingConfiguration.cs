using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApi.DataAccess.Entities;

namespace NewsApi.DataAccess.Configuration;

public class RatingConfiguration : IEntityTypeConfiguration<RatingEntity>
{
    public void Configure(EntityTypeBuilder<RatingEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value).IsRequired();
    }
}