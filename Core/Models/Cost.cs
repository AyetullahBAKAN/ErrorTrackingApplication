namespace Core.Models
{
    public class Cost : BaseEntity
    {
        public string Description { get; set; }
        public double Time { get; set; }
        public decimal Amount { get; set; } // miktar
        public Guid FieldId { get; set; }
        public virtual Field Field { get; set; }
        public Guid MoneyTypeId { get; set; }
        public virtual MoneyType MoneyType { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
