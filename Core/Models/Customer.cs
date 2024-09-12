namespace Core.Models
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Pattern> Patterns { get; set; }

    }
}
