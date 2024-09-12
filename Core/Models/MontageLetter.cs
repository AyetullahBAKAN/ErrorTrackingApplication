namespace Core.Models
{
    public class MontageLetter : BaseEntity
    {
        public string MontageNumber { get; set; }
        public ICollection<Pattern> Patterns { get; set; }
    }
}
