using Microsoft.EntityFrameworkCore;
using NewsApi.DataAccess;
using NewsApi.DataAccess.Repositories;
using NewsApi.Domain.Abstractions;

namespace NewsApi;

public static class AppExtensions
{
    extension(IServiceCollection services)
    {
        public void UseNpgsqlDbContext(IConfiguration configuration)
        {
            services.AddDbContext<NewsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(NewsDbContext)));
            });
        }

        public void RegisterServices(IConfiguration configuration)
        {
            services.AddScoped<INewsRepository, NewsRepository>();
        }
    }
}