using tcg_tournament_manager.domain.Enum;

namespace tcg_tournament_manager.domain.Entities
{
    public class TrainingRound
    {
        public Guid TrainingId { get; private set; }
        public Guid PlayerOne { get; private set; }
        public Guid PlayerTwo { get; private set; }
        public ERoundStatus Status { get; private set; }

        public TrainingRound()
        {
            
        }
    }
}
