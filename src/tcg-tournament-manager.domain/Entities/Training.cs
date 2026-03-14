namespace tcg_tournament_manager.domain.Entities
{
    public class Training
    {
        public string Name { get; set; }
        public DateTime StartIn { get; set; }
        public DateTime EndIn { get; set; }

        public virtual ICollection<Player> Players { get; private set; }

        public Training()
        {
            Players = new List<Player>();
        }

        public Player AddPlayer(Player player)
        {
            Players.Add(player);
            return player;
        }

        public Training CreateTraining(Guid id, string name, DateTime startIn, DateTime endIn, Guid tournamentId)
        {
            Name = name;
            StartIn = startIn;
            EndIn = endIn;
            return this;
        }
    }
}