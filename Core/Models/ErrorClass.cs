namespace Core.Models
{
    public class ErrorClass : BaseEntity
    {
        public string ShortDetail { get; set; }
        public Guid ErrorMainTitleId { get; set; }
        public ErrorMainTitle ErrorMainTitle { get; set; }
        public Guid ErrorSubGroupId { get; set; }
        public ErrorSubGroup ErrorSubGroup { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
