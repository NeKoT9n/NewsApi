namespace NewsApi.Domain.Models;

public class Rating
{
     public long Id { get; }
     public float Value { get; }
    
     private Rating(long id, float value)
     {
          Id = id;
          Value = value;
     }

     public static Rating Create(long id, float value)
     {
          return new Rating(id, value);
     }
}