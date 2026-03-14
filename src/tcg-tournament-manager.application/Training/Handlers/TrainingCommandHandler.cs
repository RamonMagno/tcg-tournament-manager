using tcg_tournament_manager.application.Shared.Commands;
using tcg_tournament_manager.application.Train.Convertes;
using tcg_tournament_manager.application.Training.Commands;
using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.domain.Interfaces;

namespace tcg_tournament_manager.application.Training.Handlers
{
    public sealed class TrainingCommandHandler : ICommandHandler<CreateTrainingCommand, TrainingDto>
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingCommandHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<TrainingDto> HandleAsync(CreateTrainingCommand command, CancellationToken cancellationToken = default)
        {
            var training =  await _trainingRepository.GetTrainingByIdAsync(command.Id);

            if (training is null)
            {
                throw new InvalidOperationException($"Training with id {command.Id} not exists.");
            }

            var trainingDto = training.ConvertToTrainDto();

            return trainingDto;
        }
    }
}
