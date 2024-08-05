namespace PlatformService.Dtos
{
    public class PlatfromReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Cost { get; set; } = string.Empty;
    }
}