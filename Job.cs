namespace Binocs
{
    public class Job
    {
        public int Id { get; set; }
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}
