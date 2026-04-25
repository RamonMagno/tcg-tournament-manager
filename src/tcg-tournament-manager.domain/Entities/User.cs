using tcg_tournament_manager.domain.Abstracts;
using tcg_tournament_manager.domain.ValueObjects;

namespace tcg_tournament_manager.domain.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public Email? Email { get; private set; }
        public string? Login { get; private set; }
        public string? Password { get; private set; }
    }
}