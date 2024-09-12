namespace Core.Models
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Pattern> Patterns { get; set; }
    }
}
