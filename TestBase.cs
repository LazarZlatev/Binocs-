using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Chrome;

namespace Binocs
{
    public abstract class TestBase
    {
        private readonly By logOut = By.Id("logout");
        private readonly By userName = By.Id("UserName");
        protected IWebDriver WebDriver;

        [SetUp]
        public void BaseTestInitialize()
        {
            CreateWebDriver();
            Log($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        private void CreateWebDriver()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();

            Log($"\nFinished test: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void BaseTestCleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Failed")
            {
                // Write log to File
                var logs = WebDriver.Manage().Logs.GetLog(LogType.Browser);
                var path = Path.Combine(TestContext.CurrentContext.TestDirectory + TestContext.CurrentContext.Test.Name + ".txt");
                var sb = new StringBuilder();

                foreach (var log in logs)
                    sb.AppendLine(log.ToString().Replace("\n", ""));

                File.AppendAllText(path, sb.ToString());

                // Save Screenshot to File
                var ts = (ITakesScreenshot)WebDriver;
                var image = ts.GetScreenshot();
                path = Path.Combine(TestContext.CurrentContext.TestDirectory + TestContext.CurrentContext.Test.Name + ".png");

                image.SaveAsFile(path);
            }
            //WaitUtilities.WaitForElementIsClickable(WebDriver, logOut).Click();
            //WaitUtilities.WaitForElementIsVisible(WebDriver, userName);

            // Close Browser
            WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();
        }
        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
