using tcg_tournament_manager.application.Train.Convertes;
using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.application.Training.Queries;
using tcg_tournament_manager.domain.Interfaces.Repositories;
using tcg_tournament_manager.domain.Shared.Queries;

namespace tcg_tournament_manager.application.Training.Handlers
{
    public sealed class TrainingQueryHandler : IQueryHandler<GetTrainingByIdQuery, TrainingDto>
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingQueryHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<TrainingDto> HandleAsync(GetTrainingByIdQuery query, CancellationToken cancellationToken = default)
        {
            var training = await _trainingRepository.GetTrainingByIdAsync(query.Id);

            if (training == null)
            {
                throw new Exception($"Training with id {query.Id} not found.");
            }

            return training.ConvertToTrainingDto();
        }
    }
}
