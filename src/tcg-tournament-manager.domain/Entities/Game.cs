using tcg_tournament_manager.domain.Abstracts;

namespace tcg_tournament_manager.domain.Entities
{
    public class Game : BaseEntity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
    }
}
