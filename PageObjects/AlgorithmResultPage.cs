using Binocs.Utilities;
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
            Assert.That(startDate, Is.EqualTo(WaitUtilities.WaitForElementIsVisible(webdriver, By.XPath(string.Format(ResultRowValue, startDate))).Text), "Record didn't find.");
        }
    }
}