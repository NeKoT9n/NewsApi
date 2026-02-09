using Microsoft.EntityFrameworkCore;
using NewsApi.DataAccess;

namespace NewsApi;

public static class AppExtensions
{
    public static void UseNpgsqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NewsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(NewsDbContext)));
        });
    }
}