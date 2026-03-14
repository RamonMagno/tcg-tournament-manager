namespace tcg_tournament_manager.application.Training.Dto
{
    public sealed record TrainingDto(string Name, DateTime? StartIn, DateTime? EndIn, IEnumerable<TrainingPlayerDto> Players);
}
