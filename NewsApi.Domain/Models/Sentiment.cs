namespace NewsApi.Domain.Models;

public class Sentiment
{
    public SentimentType Type { get; }
    public float Score { get; }
    
    private Sentiment(SentimentType type, float score)
    {
        Type = type;
        Score = score;
    }

    public static Sentiment Create(SentimentType type, float score)
    {
        return new Sentiment(type, score);
    }
}