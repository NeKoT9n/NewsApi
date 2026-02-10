namespace NewsApi.DataAccess.Entities;

public class RatingEntity
{
    public long Id { get; set; }
    public long NewsId { get; set; }
    public NewsEntity News { get; set; } = null!;
    public float Value { get; set; }
}