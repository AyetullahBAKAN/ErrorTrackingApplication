namespace Core.Models
{
    public class ErrorSubGroup : BaseEntity
    {
        public string ErrorSubGroupName { get; set; }
        public ICollection<ErrorDetailSub> ErrorDetailSubs { get; set; }
        public ICollection<ErrorMainSub> ErrorMainSubs { get; set; }
        public ICollection<ErrorType> ErrorTypes { get; set; }
        public ICollection<ErrorClass> ErrorClasses { get; set; }

    }
}
