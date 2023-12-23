namespace Binocs
{
    public interface IUser
    {
        public int JobId { get; set; }
        public int TaskId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int ResourceId { get; set; }
    }
}
