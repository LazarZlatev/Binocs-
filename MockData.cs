using Moq;

namespace Binocs
{
    public static class MockData
    {
        public static Mock<IUser> SetupMockData(DateTime startDate)
        {
            var user = new Mock<IUser>();
            user.Setup(p => p.ResourceId).Returns(100);
            user.Setup(p => p.ScheduleDate).Returns(startDate);

            user.Setup(p => p.Jobs).Returns(new List<Job>
            {
                new Job { Id = 1, Tasks = new List<Task> {
                    new Task { Id = 1 },
                    new Task { Id = 2 }}
                }
            });

            return user;
        }
    }
}
