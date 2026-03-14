namespace tcg_tournament_manager.domain.Entities
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }
        public DateTime TournamentInitIn { get; set; }
        public DateTime TournamentEndIn { get; set; }
        public string BannerUrl { get; set; }
    }
}