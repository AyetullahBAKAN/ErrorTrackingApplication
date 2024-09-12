namespace Core.Models
{
    public class Operation : BaseEntity
    {
        public string OperationNo { get; set; }
        public ICollection<Pattern> Patterns { get; set; }
    }
}
