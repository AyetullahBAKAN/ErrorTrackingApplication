namespace Core.Models
{
    public class ErrorDetailSub
    {
        public Guid ErrorDetailGroupId { get; set; }
        public virtual ErrorDetailGroup ErrorDetailGroup { get; set; }

        public Guid ErrorSubGroupId { get; set; }
        public virtual ErrorSubGroup ErrorSubGroup { get; set; }
    }
}
