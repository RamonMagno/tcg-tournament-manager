using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using tcg_tournament_manager.application.Shared.Behaviors;
using tcg_tournament_manager.application.Shared.Dispatcher;
using tcg_tournament_manager.domain.Shared.Commands;
using tcg_tournament_manager.domain.Shared.Events;
using tcg_tournament_manager.domain.Shared.Queries;

namespace tcg_tournament_manager.application.Shared.DependencyInjection
{
    internal static class MediatorConfiguration
    {
        internal static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher,  Dispatcher.Dispatcher>();
            services.RegisterHandlers();
            services.RegisterEventHandlers();
            services.RegisterValidatorsAndBehaviors();
            return services;
        }

        private static IServiceCollection RegisterHandlers(this IServiceCollection services)
        {
            var assembly = typeof(TCGTournamentManagerApplicationExtensions).Assembly;
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
                    services.AddScoped(@interface, handler);
            }

            return services;
        }

        private static IServiceCollection RegisterEventHandlers(this IServiceCollection services)
        {
            var assembly = typeof(TCGTournamentManagerApplicationExtensions).Assembly;

            var handlers = assembly.GetTypes()
                .Where(t => t is { IsAbstract: false, IsInterface: false } &&
                            t.GetInterfaces().Any(i =>
                                i.IsGenericType &&
                                i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)));

            foreach (var handler in handlers)
            {
                var interfaces = handler.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));

                foreach (var @interface in interfaces)
                    services.AddScoped(@interface, handler);
            }

            return services;
        }

        private static IServiceCollection RegisterValidatorsAndBehaviors(this IServiceCollection services)
        {
            var assembly = typeof(TCGTournamentManagerApplicationExtensions).Assembly;

            services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped, includeInternalTypes: true);

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationPipelineBehavior<,>));

            return services;
        }
    }
}