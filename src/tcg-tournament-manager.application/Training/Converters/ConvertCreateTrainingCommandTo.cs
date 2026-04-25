using tcg_tournament_manager.application.Training.Commands;

namespace tcg_tournament_manager.application.Training.Converters
{
    internal static class ConvertCreateTrainingCommandTo
    {
        internal static domain.Entities.Training ConvertToTrainingEntity(this CreateTrainingCommand command)
        {
            return domain.Entities.Training.Create(command.Name!,
                                                           Guid.CreateVersion7(),
                                                           command.Description,
                                                           "invite-url",
                                                           Guid.CreateVersion7(),
                                                           command.PlayersLimit);
        }
    }
}
