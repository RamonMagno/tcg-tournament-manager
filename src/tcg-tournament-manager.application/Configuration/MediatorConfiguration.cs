using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.application.Shared.Commands;
using tcg_tournament_manager.application.Shared.Dispatcher;
using tcg_tournament_manager.application.Shared.Queries;

namespace tcg_tournament_manager.application.Configuration
{
    internal static class MediatorConfiguration
    {
        internal static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();

            var assembly = typeof(ApplicationExtensions).Assembly;

            var handlerInterfaces = new[]
            {
                typeof(ICommandHandler<>),
                typeof(ICommandHandler<,>),
                typeof(IQueryHandler<,>)
            };

            var handlers = assembly.GetTypes()
                .Where(t => t is { IsAbstract: false, IsInterface: false } &&
                            t.GetInterfaces().Any(i =>
                                i.IsGenericType &&
                                handlerInterfaces.Contains(i.GetGenericTypeDefinition())));

            foreach (var handler in handlers)
            {
                var interfaces = handler.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        handlerInterfaces.Contains(i.GetGenericTypeDefinition()));

                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, handler);
                }
            }

            return services;
        }
    }
}
