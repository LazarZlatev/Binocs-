using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace Binocs.Utilities
{
    public static class WaitUtilities
    {
        internal static int Seconds = 30;

        public static TimeSpan PageLoadTimeout => TimeSpan.FromSeconds(Seconds);
        public static IWebElement WaitForElementIsClickable(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, PageLoadTimeout);
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static IWebElement WaitForElementIsVisible(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, PageLoadTimeout);
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static ReadOnlyCollection <IWebElement> WaitForElementAreVisible(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, PageLoadTimeout);
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

    }
}
