using tcg_tournament_manager.domain.Entities;
using tcg_tournament_manager.domain.Interfaces.Repositories;
using tcg_tournament_manager.infrastructure.data.Context;

namespace tcg_tournament_manager.infrastructure.data.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(TCGTournamentManagerContext context) : base(context)
        {
        }

        public Task<Training> GetTrainingByIdAsync(Guid id)
        {
            var training = Training.Create("Treino de teste",
                                            Guid.CreateVersion7(),
                                            "decricao",
                                            "inviteUrl",
                                            Guid.CreateVersion7(),
                                            20);

            return Task.FromResult(training);
        }
    }
}
