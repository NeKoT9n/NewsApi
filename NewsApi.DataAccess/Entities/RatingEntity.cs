namespace NewsApi.DataAccess.Entities;

public class RatingEntity
{
    public long Id { get; init; }
    public long NewsId { get; init; }
    public NewsEntity News { get; init; } = null!;
    public float Value { get; init; }
}