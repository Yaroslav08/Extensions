using System;
namespace Extensions.Logging.Models
{
    public class LogItem
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public UserInfo User { get; set; }
        public RequestInfo Request { get; set; }
        public DeviceInfo Device { get; set; }
        public BrowserInfo Browser { get; set; }
        public Error Error { get; set; }
    }
}