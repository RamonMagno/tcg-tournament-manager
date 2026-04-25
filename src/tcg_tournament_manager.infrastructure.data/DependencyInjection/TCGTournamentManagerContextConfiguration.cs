using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.infrastructure.data.Context;

namespace tcg_tournament_manager.infrastructure.data.DependencyInjection
{
    public static class TCGTournamentManagerContextConfiguration
    {

        public static IServiceCollection AddDatabaseDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TCGTournamentManagerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:DefaultConnection")));
            return services;
        }
    }
}
