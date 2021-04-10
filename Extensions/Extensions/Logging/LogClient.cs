using Extensions.Logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceDetectorNET;
using Shyjus.BrowserDetection;

namespace Extensions.Logging
{
    public interface ILogClient
    {
        LogItem GetLogItem();
    }




    public class LogClient : ILogClient
    {
        private readonly List<LogItem> _logs;
        private readonly IBrowserDetector _browserDetector;
        private Settings _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogClient(IHttpContextAccessor httpContextAccessor, IBrowserDetector browserDetector, Action<Settings> action)
        {
            _httpContextAccessor = httpContextAccessor;
            _logs = new List<LogItem>();
            _settings = action.Target as Settings;
            _browserDetector = browserDetector;
        }

        public LogItem GetLogItem()
        {
            var currentLog = new LogItem
            {
                User = GetUser(_httpContextAccessor.HttpContext),
                Request = GetRequest(_httpContextAccessor.HttpContext),
                Date = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString("N"),
                Device = GetDevice(_httpContextAccessor.HttpContext),
                Browser = GetBrowser(),
                Error = GetError(_httpContextAccessor.HttpContext)
            };
            _logs.Add(currentLog);
            return currentLog;
        }


        private UserInfo GetUser(HttpContext context)
        {
            var userInfo = new UserInfo();
            userInfo.AccessToken = context.GetTokenAsync("access_token").Result;
            userInfo.Name = context.User.Identity.Name;
            userInfo.AuthType = context.User.Identity.AuthenticationType;
            userInfo.Sub = context.User.Claims.FirstOrDefault(d => d.Type == "sub").Value;
            userInfo.IsAuth = context.User.Identity.IsAuthenticated;
            return userInfo;
        }

        private RequestInfo GetRequest(HttpContext context)
        {
            var requestInfo = new RequestInfo
            {
                ConnectionId = context.Connection.Id,
                TraceIdentifier = context.TraceIdentifier,
                Scheme = context.Request.Scheme,
                Path = context.Request.Path.Value,
                IP = context.Connection.RemoteIpAddress.ToString(),
                HttpVersion = context.Request.Protocol,
                IsWebSocketRequest = context.WebSockets.IsWebSocketRequest,
                Method = context.Request.Method
            };
            return requestInfo;
        }

        private DeviceInfo GetDevice(HttpContext context)
        {
            var dd = new DeviceDetector(context.Request.Headers["User-Agent"].ToString());
            dd.SkipBotDetection();
            dd.Parse();

            return new DeviceInfo
            {
                Type = dd.GetDeviceName(),
                Brand = dd.GetBrandName(),
                Model = dd.GetModel(),
                OS = _browserDetector.Browser.OS,
            };
        }

        private Error GetError(HttpContext context)
        {
            return new Error
            {

            };
        }

        private BrowserInfo GetBrowser()
        {
            return new BrowserInfo
            {
                Name = _browserDetector.Browser.Name,
                Type = _browserDetector.Browser.DeviceType,
                Version = _browserDetector.Browser.Version,
            };
        }
    }
}