using Binocs.Controllers;
using Binocs.Utilities;

namespace Binocs.Tests
{
    public class Tests : TestBase
    {
        [Test]
        [TestCase("COVID-19 (coronavirus)")]
        public void EndToEndSeleniumTest(string value)
        {
            // Act
            var algorithmResult = AlgorithmRunner.RunAlgorithm(value, WebDriver);

            // Assert
            algorithmResult.ValidateAlgorithmRun(value);
        }
    }
}