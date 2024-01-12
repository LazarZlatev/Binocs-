using Binocs.Controllers;
using FluentAssertions;

namespace Binocs.ApiTest
{
    internal class ApiTests
    {
        [Test]
        public async Task APITest()
        {
            //Arrange
            var url = "https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5";

            // Trigger the algorithm
            var result = await CurrencyController.GetCurrencies(url);

            // Validate UI output
            result.First().Currency.Should().Be("EUR");
            result.First().BaseCurrency.Should().Be("UAH");
            result.First().Buy.Should().NotBe(string.Empty);
            result.First().Sale.Should().NotBeNull(string.Empty);
        }
    }
}
