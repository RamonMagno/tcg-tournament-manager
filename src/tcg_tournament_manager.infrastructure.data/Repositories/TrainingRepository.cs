using tcg_tournament_manager.domain.Entities;
using tcg_tournament_manager.domain.Interfaces;

namespace tcg_tournament_manager.infrastructure.data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        public Task<Training> GetTrainingByIdAsync(Guid id)
        {
            try
            {
                var playerOne = new Player();
                playerOne.Id = new Guid();
                playerOne.Name = "Ramon Mello";

                var playerTwo = new Player();
                playerTwo.Id = new Guid();
                playerTwo.Name = "Penelope Oliveira";

                var training = new Training();

                training.AddPlayer(playerOne);
                training.AddPlayer(playerTwo);

                training.CreateTraining(id, "Treino legal", DateTime.Now, DateTime.Now, Guid.NewGuid());

                return Task.FromResult(training);
            }
            catch 
            {
                return null;
            }
        }
    }
}
