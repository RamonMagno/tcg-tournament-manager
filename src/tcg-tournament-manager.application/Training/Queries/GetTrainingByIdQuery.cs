using tcg_tournament_manager.application.Training.Dto;
using tcg_tournament_manager.domain.Shared.Queries;

namespace tcg_tournament_manager.application.Training.Queries
{
    public record GetTrainingByIdQuery : IQuery<TrainingDto>
    {
        public Guid Id { get; set; }

        public GetTrainingByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
