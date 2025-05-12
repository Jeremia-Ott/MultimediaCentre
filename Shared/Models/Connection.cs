namespace Shared.Models
{
    public class Connection
    {
        public required Media FromMedia { get; set; }
        public required Media ToMedia { get; set; }
        public ConnectionType Type { get; set; }
        public string? Description { get; set; }
    }

    public enum ConnectionType
    {
        None = 0,
        SpinOff = 1,
        Sequel = 2,
        Adaption = 3,
    }
}
