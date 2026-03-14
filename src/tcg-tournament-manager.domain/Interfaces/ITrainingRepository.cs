using tcg_tournament_manager.domain.Entities;

namespace tcg_tournament_manager.domain.Interfaces
{
    public interface ITrainingRepository
    {
        Task<Training> GetTrainingByIdAsync(Guid id);
    }
}
