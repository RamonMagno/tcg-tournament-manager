using Microsoft.Extensions.DependencyInjection;

namespace tcg_tournament_manager.application.Configuration
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator();
            return services;
        }
    }
}
