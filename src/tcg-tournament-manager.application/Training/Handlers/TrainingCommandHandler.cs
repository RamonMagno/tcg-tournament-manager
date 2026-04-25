using tcg_tournament_manager.application.Train.Convertes;
using tcg_tournament_manager.application.Training.Commands;
using tcg_tournament_manager.application.Training.Converters;
using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.domain.Interfaces.Repositories;
using tcg_tournament_manager.domain.Shared.Commands;

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
            var training = command.ConvertToTrainingEntity();

            //await _trainingRepository.AddAsync(training, cancellationToken);

            await Task.Delay(2);

            return training.ConvertToTrainingDto();
        }
    }
}
