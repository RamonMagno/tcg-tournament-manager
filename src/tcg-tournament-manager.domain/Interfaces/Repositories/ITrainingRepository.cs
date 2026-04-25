using tcg_tournament_manager.domain.Entities;
using tcg_tournament_manager.domain.Shared.Data;

namespace tcg_tournament_manager.domain.Interfaces.Repositories
{
    public interface ITrainingRepository: IRepository<Training>
    {
        Task<Training> GetTrainingByIdAsync(Guid id);
    }
}
