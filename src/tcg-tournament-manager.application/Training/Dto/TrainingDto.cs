namespace tcg_tournament_manager.application.Training.Dto
{
    public sealed record TrainingDto(string Name, string? Description, int? QuantityPlayers, IEnumerable<TrainingPlayerDto>? Players);
}
