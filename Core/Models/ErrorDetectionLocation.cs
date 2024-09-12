namespace Core.Models
{
    public class ErrorDetectionLocation : BaseEntity
    {
        public string ErrorLocation { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
