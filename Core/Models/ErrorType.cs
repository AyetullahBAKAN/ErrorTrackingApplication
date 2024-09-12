namespace Core.Models
{
    public class ErrorType : BaseEntity
    {


        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ErrorDetailGroupId { get; set; }
        public virtual ErrorDetailGroup ErrorDetailGroup { get; set; }
        public Guid ErrorSubGroupId { get; set; }
        public virtual ErrorSubGroup ErrorSubGroup { get; set; }
        public Guid ErrorMainTitleId { get; set; }
        public virtual ErrorMainTitle ErrorMainTitle { get; set; }

    }
}
