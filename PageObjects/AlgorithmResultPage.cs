using Binocs.Utilities;
using FluentAssertions;
using OpenQA.Selenium;

namespace Binocs.PageObjects
{
    public class AlgorithmResultPage
    {
        private IWebDriver webdriver;
        private By ResultRows = By.XPath(".//*[@id='search']/div/div/div");
        private string ResultRowValue = ".//div[@id='rso']//a//h3[contains(text(),'{0}')]";

        public AlgorithmResultPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        internal void ValidateAlgorithmRun(string startDate)
        {
           WaitUtilities.WaitForElementsAreVisible(webdriver, ResultRows).Should().NotBeEmpty();
           var elemList = WaitUtilities.WaitPresenceOfElements(webdriver, By.XPath(string.Format(ResultRowValue, startDate)));
           elemList.ForEach(elem => { elem.Text.Should().Contain(startDate); });
        }
    }
}