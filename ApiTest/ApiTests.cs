using Binocs.Controllers;
using FluentAssertions;

namespace Binocs.ApiTest
{
    internal class ApiTests
    {
        [Test]
        [TestCase("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5")]
        public async Task APITest(string url)
        {
            // Act
            var result = await CurrencyController.GetCurrencies(url);

            // Assert
            result.First().Currency.Should().Be("EUR");
            result.First().BaseCurrency.Should().Be("UAH");
            result.First().Buy.Should().NotBe(string.Empty);
            result.First().Sale.Should().NotBeNull(string.Empty);
        }
    }
}
