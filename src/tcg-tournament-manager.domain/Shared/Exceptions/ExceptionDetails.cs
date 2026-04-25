using System.Text.Json;

namespace tcg_tournament_manager.domain.Shared.Exceptions
{
    public sealed record ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Trace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
