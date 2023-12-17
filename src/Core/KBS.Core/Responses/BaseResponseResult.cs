using System.Net;

namespace KBS.Core.Responses;

public record BaseResponseResult
{
    public bool Succeeded { get; set; } = false;
    public string? ResponseMessage { get; set; } = nameof(Succeeded);
    public ResponseResultType ResponseResultType { get; set; } = ResponseResultType.Succeeded;
    public IEnumerable<BaseError>? Errors { get; set; }
    public IEnumerable<BaseMetadata>? Metadatas { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
}
