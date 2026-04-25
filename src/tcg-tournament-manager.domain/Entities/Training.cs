using tcg_tournament_manager.domain.Abstracts;

namespace tcg_tournament_manager.domain.Entities
{
    public class Training : BaseEntity
    {
        public string? Name { get; private set; }
        public Guid PlayerHostId { get; private set; }
        public string? Description { get; private set; }
        public string? InviteUrl { get; private set; }
        public Guid GameId { get; private set; }
        public int? PlayersLimit { get; private set; }
        public virtual ICollection<Player>? ParticipantPlayers { get; private set; }

        protected Training(string name, Guid playerHostId, string? description, string? inviteUrl, Guid gameId, int? playersLimit)
        {
            Name = name;
            PlayerHostId = playerHostId;
            Description = description;
            InviteUrl = inviteUrl;
            GameId = gameId;
            PlayersLimit = playersLimit;

            ParticipantPlayers = new List<Player>();
        }

        private Training()
        {
            ParticipantPlayers = new List<Player>();
        }

        public static Training Create(string name, Guid playerHostId, string? description, string? inviteUrl, Guid gameId, int? playersLimit)
        {
            var training = new Training(name, playerHostId, description, inviteUrl, gameId, playersLimit);
            return training;
        }
    }
}