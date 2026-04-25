using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.domain.Shared.Commands;

namespace tcg_tournament_manager.application.Training.Commands
{
    public sealed record CreateTrainingCommand : ICommand<TrainingDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? GameId { get; set; }
        public int? PlayersLimit { get; set; }

        public CreateTrainingCommand(string? name,
                                     string? description,
                                     Guid? gameId,
                                     int? playersLimit)
        {
            Name = name;
            Description = description;
            GameId = gameId;
            PlayersLimit = playersLimit;
        }
    }
}
