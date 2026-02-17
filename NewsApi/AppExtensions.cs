using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewsApi.Application.Features.Queries;
using NewsApi.Application.Mappers;
using NewsApi.Consumers;
using NewsApi.DataAccess;
using NewsApi.Options;

namespace NewsApi;

public static class AppExtensions
{
    extension(IServiceCollection services)
    {
        public void RegisterOptions(IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(
                configuration.GetSection(RabbitMqOptions.SECTION_NAME));
        }
        
        public void UseNpgsqlDbContext(IConfiguration configuration)
        {
            services.AddDbContext<NewsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(NewsDbContext)));
            });
        }

        public void RegisterServices()
        {
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(typeof(GetNewsByIdHandler).Assembly));
        }

        public void RegisterMappers()
        {
            services.AddSingleton<NewsMapper>();
        }

        public void RegisterMessageBroker()
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<NewsMessageConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<RabbitMqOptions>>().Value;

                    cfg.Host(options.Host, options.VirtualHost, h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });
                    
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
        

    }
}