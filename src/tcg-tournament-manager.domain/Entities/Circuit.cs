using tcg_tournament_manager.domain.Abstract;

namespace tcg_tournament_manager.domain.Entities
{
    public class Circuit : ChampionshipAbstract
    {
        public virtual ICollection<Lap> Laps { get; private set; }

        public Circuit()
        {
            Laps = new HashSet<Lap>();
        }
    }
}