using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.domain.Interfaces.Repositories;
using tcg_tournament_manager.domain.Shared.Data;
using tcg_tournament_manager.infrastructure.data.Repositories;

namespace tcg_tournament_manager.infrastructure.data.DependencyInjection
{
    public static class TCGTournamentManagerInfrastructureDataExtensions
    {
        public static IServiceCollection AddInfrastructureDataDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseDependencyInjection(configuration);

            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
