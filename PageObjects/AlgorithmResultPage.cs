using Binocs.Utilities;
using FluentAssertions;
using OpenQA.Selenium;

namespace Binocs.PageObjects
{
    public class AlgorithmResultPage
    {
        private IWebDriver webdriver;
        private By ResultRow = By.XPath("(.//*[@id='search']/div/div/div)[1]");

        public AlgorithmResultPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        internal void ValidateAlgorithmRun(string startDate)
        {
           WaitUtilities.WaitForElementAreVisible(webdriver, ResultRow).Should().NotBeEmpty();
        }
    }
}