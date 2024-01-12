using Newtonsoft.Json;
using System.Text;

namespace Binocs.API
{
    public class ApiBase
    {
        protected static async Task<HttpResponseMessage> SendRequest(HttpMethod method, string url, object? input = null)
        {
            using var request = GetRequest(method, url, input);

            if (input != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(input, SerializerSettings), Encoding.UTF8, "application/json");

            return await SendRequest(request);
        }
        protected static HttpRequestMessage GetRequest(HttpMethod method, string url, object? body = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = GetJsonBody(body),
            };
            request.Content = GetJsonBody(body);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "en-US");
            request.Headers.Add("X-Timestamp", DateTime.UtcNow.ToString("o"));
            return request;
        }

        public static async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request)
        {
            var start = DateTime.UtcNow;
            var response = await new HttpClient().SendAsync(request);
            return response;
        }

        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        private static StringContent? GetJsonBody(object? body) => body is null
           ? null : new StringContent(JsonConvert.SerializeObject(body, SerializerSettings), Encoding.UTF8,
               "application/json");
    }
}
