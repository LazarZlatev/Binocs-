using Newtonsoft.Json;

namespace Binocs.Controllers
{
    public class GetCurrenciesResponseModel
    {
        [JsonProperty("ccy")]
        public string? Currency { get; set; } 
        [JsonProperty("base_ccy")]
        public string? BaseCurrency { get; set; }
        [JsonProperty("buy")]
        public string? Buy { get; set; }
        [JsonProperty("sale")]
        public string? Sale { get; set; }

    }
}