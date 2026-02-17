using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Entities;

public class SentimentEntity
{
    public long NewsId { get; init; }
    public required NewsEntity News { get; init; }
    public SentimentType Type { get; init; }
    public float Score { get; init; }
    
}