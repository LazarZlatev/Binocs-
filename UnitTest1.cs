namespace Binocs
{
    public class Tests
    {
        public class TestData
        {
            public DateTime StartDate { get; set; }
        }

        private static readonly TestData[] _testData = new[]{
             new TestData(){ StartDate = DateTime.Today },
             new TestData(){ StartDate = DateTime.Today.AddDays(1)},
             new TestData(){ StartDate = DateTime.Today.AddDays(7)},
        };

        [Test]
        public void EndToEndSeleniumTest([ValueSource(nameof(_testData))] TestData testData)
        {
            // Mock data and assumptions
            Console.WriteLine(testData.StartDate);
        }
    }
}