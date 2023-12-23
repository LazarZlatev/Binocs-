namespace Binocs
{
    public class Tests: TestBase
    {
        public class TestData
        {
            public DateTime StartDate { get; set; }
        }

        private static readonly TestData[] _startDate = new[]{
             new TestData(){ StartDate = DateTime.Today },
             new TestData(){ StartDate = DateTime.Today.AddDays(1)},
             new TestData(){ StartDate = DateTime.Today.AddDays(7)},
        };

        [Test]
        public void EndToEndSeleniumTest([ValueSource(nameof(_startDate))] TestData Date)
        {
            // Mock data and assumptions
            var user = MockData.SetupMockData(Date.StartDate);

            //// Trigger the algorithm
            //AlgorithmRunner.RunAlgorithm(testData);

            // Validate UI output
            UIValidator.ValidateScheduleTable(user, Date.StartDate);
        }
    }
}