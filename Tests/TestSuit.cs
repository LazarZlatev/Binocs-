using Binocs.Controllers;
using Binocs.Utilities;
using FluentAssertions;

namespace Binocs.Tests
{
    public class Tests : TestBase
    {
        [Test]
        [TestCase("COVID-19 (coronavirus)")]
        public void EndToEndSeleniumTest(string value)
        {
            // Trigger the algorithm
            var algorithmResult = AlgorithmRunner.RunAlgorithm(value, WebDriver);

            // Validate UI output
            algorithmResult.ValidateAlgorithmRun(value);
        }

    }
}