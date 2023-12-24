namespace Binocs
{
    public interface IUser
    {
        public int Id { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int ResourceId { get; set; }
    }
}
