namespace KBS.Core.Responses
{
    public record BaseError
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
