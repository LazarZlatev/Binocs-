using Binocs.Utilities;
using OpenQA.Selenium;

namespace Binocs.PageObjects
{
    public class AlgorithmRunnerPage
    {
        private IWebDriver webDriver;
        public By Search = By.XPath(".//textarea[@title='Search']");

        public AlgorithmRunnerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public AlgorithmResultPage RunAlgorithm(string testData)
        {
            WaitUtilities.WaitForElementIsClickable(webDriver, Search).SendKeys(testData.ToString());
            WaitUtilities.WaitForElementIsClickable(webDriver, Search).SendKeys(Keys.Enter);

            return new AlgorithmResultPage(webDriver);
        }
    }
}