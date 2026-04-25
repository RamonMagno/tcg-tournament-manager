using Microsoft.EntityFrameworkCore;
using tcg_tournament_manager.domain.Shared.Data;

namespace tcg_tournament_manager.infrastructure.data.Context
{
    public class TCGTournamentManagerContext : DbContext, IUnitOfWork
    {
        public TCGTournamentManagerContext(DbContextOptions<TCGTournamentManagerContext> options)
            : base(options)
        {
            
        }
    }
}
