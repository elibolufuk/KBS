namespace KBS.Core.Responses
{
    public record BaseError
    {
        public string? Property { get; set; }
        public string? Description { get; set; }
    }
}
