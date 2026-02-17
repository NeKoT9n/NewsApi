using MassTransit;
using Shared.Models.Messages;

namespace NewsApi.Consumers;

public class NewsMessageConsumer(ILogger<NewsMessageConsumer> logger) : IConsumer<RawNewsScraped>
{
    public async Task Consume(ConsumeContext<RawNewsScraped> context)
    {
        var message = context.Message;

        logger.LogInformation("News has received: {Title}", message.Title);
        
        await Task.CompletedTask;
    }
}