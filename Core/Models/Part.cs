namespace Core.Models
{
    public class Part : BaseEntity
    {
        public string PartNo { get; set; }
        public ICollection<Pattern> Patterns { get; set; }
    }
}
