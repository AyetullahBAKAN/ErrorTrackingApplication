namespace Core.Models
{
    public class ErrorMainTitle : BaseEntity
    {
        public string ErrorMainTitleName { get; set; }
        public ICollection<ErrorMainSub> ErrorMainSubs { get; set; }
        public ICollection<ErrorType> ErrorTypes { get; set; }
        public ICollection<ErrorClass> ErrorClasses { get; set; }
    }
}
