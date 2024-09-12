namespace Core.Models
{
    public class ErrorClosingReason : BaseEntity
    {
        public string Reason { get; set; }
        public ICollection<SolutionAndStandardizition> SolutionAndStandardizitions { get; set; }

    }
}
