using tcg_tournament_manager.domain.Abstracts;
using tcg_tournament_manager.domain.Enum;

namespace tcg_tournament_manager.domain.Entities
{
    public class TrainingMatch : BaseEntity
    {
        public Guid TrainingId { get; private set; }
        public Guid PlayerOneId { get; private set; }
        public Guid PlayerTwoId { get; private set; }
        public Guid? WinnerPlayerId { get; private set; }
        public ERoundStatus Status { get; private set; }

        public TrainingMatch()
        {
            
        }
    }
}
