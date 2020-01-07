using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using fantasy_bachelor.API.Features.Rankings;
using fantasy_bachelor.API.Infrastructure.Lookup;
using fantasy_bachelor.API.Features.Users;

namespace fantasy_bachelor.API
{
    public partial class Startup
    {
        public static void ConfigureScopedServices(IServiceCollection services)
        {
            //Shared
            services.AddScoped<ILookupRepository, LookupRepository>();

            //Rankings
            services.AddScoped<IRankingsService, RankingsService>();
            services.AddScoped<IRankingsRepository, RankingsRepository>();

            //Users
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
