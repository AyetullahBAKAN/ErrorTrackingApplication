namespace Core.Models
{
    public class SolutionAndStandardizition : BaseEntity
    {
        public string SolutionShort { get; set; }
        public string SolutionPerma { get; set; }
        public string SolutionDetail { get; set; }
        public string HowErrorClose { get; set; }
        public Guid ErrorClosingReasonId { get; set; }
        public virtual ErrorClosingReason ErrorClosingReason { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
        public ICollection<MediaSolutionAndStandardizition> MediaSolutionAndStandardizitions { get; set; }

    }
}
