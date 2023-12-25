using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Chrome;
using Binocs.PageObjects;
using System.Diagnostics;

namespace Binocs.Utilities
{
    public abstract class TestBase
    {
        protected IWebDriver WebDriver;
        protected AlgorithmRunnerPage? Login;
        private readonly string Url = "https://www.google.com/";

        [SetUp]
        public void BaseTestInitialize()
        {
            CreateWebDriver();
            Log($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        private void CreateWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            var arguments = new[]
            {
                "--allow-insecure-localhost",
                "--disable-extensions",
                "--disable-internal-flash",
                "--disable-infobars",
                "--disable-plugins-discovery",
                "--window-size=1920,1080",
                "--test-type",
				//"--headless"
			};
            chromeOptions.AddArguments(arguments);
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "en-us");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);


            // Auto Save for files
            chromeOptions.AddUserProfilePreference("download.default_directory", Path.GetTempPath());

            WebDriver = new ChromeDriver(chromeOptions);
            WebDriver.Navigate().GoToUrl(Url);
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

            // Close Browser
            WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();

            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }
        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
