using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Extensions.Geo
{
    public abstract class IpAPIClient
    {
        private const string BaseUrl = "http://ip-api.com/json/";
        private static HttpClient httpClient = new HttpClient();

        public static async Task<IPGeo> GetFullInfo(string ip)
        {
            if (ip == null) throw new ArgumentNullException(nameof(ip));
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(20);
            var resposne = await httpClient.GetAsync($"{ip}?fields=66846719");
            return JsonSerializer.Deserialize<IPGeo>(await resposne.Content.ReadAsStringAsync());
        }

        public static async Task<IPGeo> GetShortInfo(string ip)
        {
            if (ip == null) throw new ArgumentNullException(nameof(ip));
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(20);
            var response = await httpClient.GetAsync($"{ip}?fields=18014429");
            return JsonSerializer.Deserialize<IPGeo>(await response.Content.ReadAsStringAsync());
        }
    }
}
