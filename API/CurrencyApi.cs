using Binocs.Controllers;

namespace Binocs.API
{
    public class CurrencyApi : ApiBase
    {
        internal static async Task<ApiResponse> GetCurrencies(string url)
        {
            var response = await SendRequest(HttpMethod.Get, url);

            return ApiResponse.Create<List<GetCurrenciesResponseModel>>(response);
        }
    }
}
