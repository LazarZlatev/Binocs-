using FluentAssertions;
using Moq;

namespace Binocs
{
    public static class UIValidator
    {
        public static void ValidateScheduleTable(Mock<IUser> user, DateTime startDate)
        {
            user.Object.JobId.Should().Be(1);
            user.Object.TaskId.Should().Be(10);
            user.Object.ResourceId.Should().Be(100);
            user.Object.ScheduleDate.Should().Be(startDate);    
        }
    }
}
