namespace Extensions.Logging.Models
{
    public class RequestInfo
    {
        public string IP { get; set; }
        public string HttpVersion { get; set; }
        public string Path { get; set; }
        public string Scheme { get; set; }
        public string Method { get; set; }
        public string ConnectionId { get; set; }
        public string TraceIdentifier { get; set; }
        public bool IsWebSocketRequest { get; set; }
    }
}