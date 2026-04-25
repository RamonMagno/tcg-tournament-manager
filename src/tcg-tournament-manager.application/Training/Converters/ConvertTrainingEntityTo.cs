using tcg_tournament_manager.application.Training.Dto;

namespace tcg_tournament_manager.application.Train.Convertes
{
    internal static class ConvertTrainingEntityTo
    {
        internal static TrainingDto ConvertToTrainingDto(this domain.Entities.Training training)
        {
            var players = training.ParticipantPlayers?.Select(x => new TrainingPlayerDto(x.Name));

            var trainingDto = new TrainingDto(training.Name,
                                              training.Description,
                                              training.ParticipantPlayers?.Count ?? 0,
                                              players);

            return trainingDto;
        }
    }
}
