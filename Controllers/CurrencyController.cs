using Binocs.API;

namespace Binocs.Controllers
{
    public class CurrencyController
    {
        public static async Task<List<GetCurrenciesResponseModel>> GetCurrencies(string url)
        {
            var apiResponse = await CurrencyApi.GetCurrencies(url);

            return (List<GetCurrenciesResponseModel>)apiResponse.Response!;
        }
    }
}