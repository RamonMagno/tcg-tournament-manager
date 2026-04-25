namespace tcg_tournament_manager.presentation.webapi.ViewModel
{
    public sealed record CreateTrainingViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? GameId { get; set; }
        public int? PlayersLimit { get; set; }
    }
}
