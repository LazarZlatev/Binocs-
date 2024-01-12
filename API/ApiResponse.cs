using Newtonsoft.Json;
using OpenQA.Selenium;
using System.Net;

namespace Binocs.API
{
    public record ApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Uri? Endpoint { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorResponse? Error { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object? Response { get; set; }

        public static ApiResponse Create<T>(HttpResponseMessage response) where T : class
        {
            var apiResponse = new ApiResponse
            {
                StatusCode = response.StatusCode,
                Endpoint = response.RequestMessage?.RequestUri
            };

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                apiResponse.Response = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                apiResponse.Error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return apiResponse;
        }

    }
}
