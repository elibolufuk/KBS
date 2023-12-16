namespace KBS.Core.Responses;

public record BaseResponseResult
{
    public bool Succeeded { get; set; } = false;
    public string? ResponseMessage { get; set; } = nameof(Succeeded);
    public IEnumerable<BaseError>? Errors { get; set; }
    public IEnumerable<BaseMetadata>? Metadatas { get; set; }
}
