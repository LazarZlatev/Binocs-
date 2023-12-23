using Moq;

namespace Binocs
{
    public static class MockData
    {
        public static Mock<IUser> SetupMockData(DateTime startDate)
        {
            var user = new Mock<IUser>();
            user.SetupGet(p => p.JobId).Returns(1);
            user.SetupGet(p => p.TaskId).Returns(10);
            user.SetupGet(p => p.ResourceId).Returns(100);
            user.SetupGet(p => p.ScheduleDate).Returns(startDate);

            return user;
        }
    }
}
