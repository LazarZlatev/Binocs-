using OpenQA.Selenium;

namespace Binocs.PageObjects
{
    public class AlgorithmResultPage
    {
        private IWebDriver webdriver;
        private By ResultRow = By.Id("login");

        public AlgorithmResultPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        internal void ValidateAlgorithmRun(string startDate)
        {
           // WaitUtilities.WaitForElementIsVisible(webdriver, ResultRow);
        }
    }
}