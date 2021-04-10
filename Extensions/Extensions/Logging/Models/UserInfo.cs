namespace Extensions.Logging.Models
{
    public class UserInfo
    {
        public string Sub { get; set; }
        public string Name { get; set; }
        public bool IsAuth { get; set; }
        public string AuthType { get; set; }
        public string AccessToken { get; set; }
        public string Cookie { get; set; }
    }
}