using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Entities;

public class SentimentEntity
{
    public long NewsId { get; set; }
    public required NewsEntity News { get; set; }
    public SentimentType Type { get; set; }
    public float Score { get; set; }
    
}