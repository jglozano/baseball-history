using BaseballHistory.Data.Repositories;
using BaseballHistory.Domain.Repositories;
using BaseballHistory.Domain.Services;
using BaseballHistory.Domain.Supervisor;
using Microsoft.OpenApi.Models;

namespace BaseballHistory.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAllstarFullRepository, AllstarFullRepository>()
                .AddScoped<IAppearanceRepository, AppearanceRepository>()
                .AddScoped<IAwardsManagerRepository, AwardsManagerRepository>()
                .AddScoped<IAwardsPlayerRepository, AwardsPlayerRepository>()
                .AddScoped<IAwardsShareManagerRepository, AwardsShareManagerRepository>()
                .AddScoped<IAwardsSharePlayerRepository, AwardsSharePlayerRepository>()
                .AddScoped<IBattingRepository, BattingRepository>()
                .AddScoped<IBattingPostRepository, BattingPostRepository>()
                .AddScoped<ICollegePlayingRepository, CollegePlayingRepository>()
                .AddScoped<IFieldingRepository, FieldingRepository>()
                .AddScoped<IFieldingOfRepository, FieldingOfRepository>()
                .AddScoped<IFieldingOfsplitRepository, FieldingOfsplitRepository>()
                .AddScoped<IFieldingPostRepository, FieldingPostRepository>()
                .AddScoped<IHallOfFameRepository, HallOfFameRepository>()
                .AddScoped<IHomeGameRepository, HomeGameRepository>()
                .AddScoped<IManagerRepository, ManagerRepository>()
                .AddScoped<IManagersHalfRepository, ManagersHalfRepository>()
                .AddScoped<IParkRepository, ParkRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IPitchingRepository, PitchingRepository>()
                .AddScoped<IPitchingPostRepository, PitchingPostRepository>()
                .AddScoped<IPlayerBattingTotalRepository, PlayerBattingTotalRepository>()
                .AddScoped<IPlayerFieldingTotalRepository, PlayerFieldingTotalRepository>()
                .AddScoped<IPlayerPitchingTotalRepository, PlayerPitchingTotalRepository>()
                .AddScoped<ISalaryRepository, SalaryRepository>()
                .AddScoped<ISchoolRepository, SchoolRepository>()
                .AddScoped<ISeriesPostRepository, SeriesPostRepository>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddScoped<ITeamBattingTotalRepository, TeamBattingTotalRepository>()
                .AddScoped<ITeamFieldingTotalRepository, TeamFieldingTotalRepository>()
                .AddScoped<ITeamPitchingTotalRepository, TeamPitchingTotalRepository>()
                .AddScoped<ITeamsFranchiseRepository, TeamsFranchiseRepository>()
                .AddScoped<ITeamsHalfRepository, TeamsHalfRepository>();
        }

        public static void ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IBaseballHistorySupervisor, BaseballHistorySupervisor>();
        }

        public static void AddAPILogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void AddCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Chinook Music Store API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Chris Woodruff",
                        Email = string.Empty,
                        Url = new Uri("https://chriswoodruff.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
            });
        }

        public static void AddUriService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext!.Request;
                var uri = string.Concat(request.Scheme, "://" ,request.Host.ToUriComponent());
                return new UriService(uri);
            });
        }
    }
}