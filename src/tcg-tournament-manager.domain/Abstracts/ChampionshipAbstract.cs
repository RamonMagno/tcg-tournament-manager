namespace tcg_tournament_manager.domain.Abstract
{
    public abstract class ChampionshipAbstract
    {
        public string Name { get; set; }
        public DateTime StartIn { get; set; }
        public DateTime EndIn { get; set; }
        public string? BannerUrl { get; set; }
    }
}