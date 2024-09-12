namespace Core.Models
{
    public class ErrorMainSub
    {
        public Guid ErrorSubGroupId { get; set; }
        public virtual ErrorSubGroup ErrorSubGroup { get; set; }

        public Guid ErrorMainTitleId { get; set; }
        public virtual ErrorMainTitle ErrorMainTitle { get; set; }
    }
}
