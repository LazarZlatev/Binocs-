using Binocs.Controllers;
using Binocs.TestData;
using Binocs.Utilities;
namespace Binocs.Tests
{
    public class Tests : TestBase
    {
        [Test]
        public void EndToEndSeleniumTest([ValueSource(nameof(MyTestSource))] TestingData Date)
        {
            // Mock data and assumptions
            var user = MockData.SetupMockData(Date.StartDate);

            // Trigger the algorithm
            var algorithmResult = AlgorithmRunner.RunAlgorithm(Date.StartDate, WebDriver);

            // Validate Mock output
            MockDataValidator.ValidateScheduleTable(user, Date.StartDate);

            // Validate UI output
            algorithmResult.ValidateAlgorithmRun(Date.StartDate);
        }

        public static readonly TestingData[] MyTestSource = new[]{
             new TestingData(){ StartDate = DateTime.Now.ToString("dd MMMM yyyy")},
             new TestingData(){ StartDate = DateTime.Now.Add(TimeSpan.FromDays(1)).ToString("dd MMMM yyyy")},
        };
    }
}