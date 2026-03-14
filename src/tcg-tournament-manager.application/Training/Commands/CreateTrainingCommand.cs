using tcg_tournament_manager.application.Shared.Command;
using tcg_tournament_manager.application.Training.Dto;

namespace tcg_tournament_manager.application.Training.Commands
{
    public sealed record CreateTrainingCommand : ICommand<TrainingDto>
    {
        public Guid Id { get; set; }
        public CreateTrainingCommand(Guid id)
        {
            Id = id;


        }
    }
}
