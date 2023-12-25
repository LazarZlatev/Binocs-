using Binocs.Models;
using FluentAssertions;
using Moq;

namespace Binocs.Controllers
{
    public static class MockDataValidator
    {
        public static void ValidateScheduleTable(Mock<IUser> user, string startDate)
        {
            user.Object.Jobs?.First().Id.Should().Be(1);
            user.Object.Jobs?.First().Tasks?.First().Id.Should().Be(1);
            user.Object.Jobs?.First().Tasks?.Last().Id.Should().Be(2);
            user.Object.Jobs?.First().Tasks?.Count.Should().Be(2);
            user.Object.ResourceId.Should().Be(100);
            user.Object.ScheduleDate.Should().Be(startDate);
        }

    }
}
