namespace Core.Models
{
    public class MediaSolutionAndStandardizition
    {
        public Guid MediaId { get; set; }
        public virtual Media Media { get; set; }
        public Guid SolutionAndStandardizitionId { get; set; }
        public virtual SolutionAndStandardizition SolutionAndStandardizition { get; set; }
    }
}
