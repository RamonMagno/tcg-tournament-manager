using Microsoft.Extensions.DependencyInjection;

namespace tcg_tournament_manager.application.Shared.DependencyInjection
{
    public static class TCGTournamentManagerApplicationExtensions
    {
        public static IServiceCollection AddApplicationDepedencyInjection(this IServiceCollection services)
        {
            services.AddMediator();
            return services;
        }
    }
}
