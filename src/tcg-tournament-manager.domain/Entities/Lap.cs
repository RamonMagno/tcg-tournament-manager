using tcg_tournament_manager.domain.Abstract;

namespace tcg_tournament_manager.domain.Entities
{
    public class Lap : ChampionshipAbstract
    {
        public virtual ICollection<User> Users { get; set; }

        public Lap()
        {
            Users = new HashSet<User>();
        }
    }
}