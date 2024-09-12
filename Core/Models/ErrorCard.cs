namespace Core.Models
{
    public class ErrorCard : BaseEntity
    {
        public int PageNumber { get; set; }
        public string FormNumber { get; set; }
        public int RevNumber { get; set; }
        public DateTime DateStart { get; set; } 
        public DateTime DateFinish { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PatternId { get; set; }
        public Pattern Pattern { get; set; }
        public Guid ErrorDefineId { get; set; }
        public ErrorDefine ErrorDefine { get; set; }
        public Guid ErrorClassId { get; set; }
        public ErrorClass ErrorClass { get; set; }
        public Guid RootAnalysisId { get; set; }
        public RootAnalysis RootAnalysis { get; set; }
        public Guid SolutionAndStandardizitionId { get; set; }
        public SolutionAndStandardizition SolutionAndStandardizition { get; set; }
        public Guid CostId { get; set; }
        public Cost Cost { get; set; }
        public Guid ErrorDetectionLocationId { get; set; }
        public ErrorDetectionLocation ErrorDetectionLocation { get; set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public Guid StateId { get; set; }
        public State States { get; set; }

    }
}
