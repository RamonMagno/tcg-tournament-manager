using tcg_tournament_manager.application.Training.Dto;

namespace tcg_tournament_manager.application.Train.Convertes
{
    internal static class ConvertTrainingEntityTo
    {
        internal static TrainingDto ConvertToTrainDto(this domain.Entities.Training training)
        {
            var players = training.Players.Select(x => new TrainingPlayerDto
            {
                Name = x.Name
            });

            var trainingDto = new TrainingDto
            {
                Name = training.Name,
                StartIn = training.StartIn,
                EndIn = training.EndIn,
                Players = players
            };

            return trainingDto;
        }
    }
}
