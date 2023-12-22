namespace Binocs
{
    public class TestBase
    {
        private static void Log(string message)
        {
            Console.WriteLine(message);
        }

        [SetUp]
        public void TestInitialize()
        {
            Log($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void TestCleanup()
        {
            Log($"\nFinished test: {TestContext.CurrentContext.Test.Name}");
        }
    }
}
