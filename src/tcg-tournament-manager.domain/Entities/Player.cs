using tcg_tournament_manager.domain.Abstracts;

namespace tcg_tournament_manager.domain.Entities
{
    public class Player : BaseEntity
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
    }
}
