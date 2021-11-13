using System.Runtime.InteropServices;
using BaseballHistory.Data;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = String.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                connection = configuration.GetConnectionString("BaseballStatsDbWindows");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                     RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                connection = configuration.GetConnectionString("BaseballStatsDbDocker");

            services.AddDbContextPool<BaseballStatsContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}