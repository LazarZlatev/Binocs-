namespace Binocs.Models
{
    public interface IUser
    {
        public int Id { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public string ScheduleDate { get; set; }
        public int ResourceId { get; set; }
    }
}
