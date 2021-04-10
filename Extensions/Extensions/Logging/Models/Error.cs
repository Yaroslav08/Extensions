using System;
namespace Extensions.Logging.Models
{
    public class Error
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}