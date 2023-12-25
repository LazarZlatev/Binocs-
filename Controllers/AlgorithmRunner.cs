using Binocs.PageObjects;
using OpenQA.Selenium;

namespace Binocs.Controllers
{
    public static class AlgorithmRunner
    {
        internal static AlgorithmResultPage RunAlgorithm(string testData, IWebDriver webDriver)
        {
            var algorithmRunnerPage = new AlgorithmRunnerPage(webDriver);
            return algorithmRunnerPage.RunAlgorithm(testData);
        }
    }
}
