namespace Core.Models
{
    public class ErrorDetailGroup : BaseEntity
    {
        public string ErrorDetailGroupName { get; set; }
        public ICollection<ErrorDetailSub> ErrorDetailSubs { get; set; }
        public ICollection<ErrorType> ErrorTypes { get; set; }
    }
}
