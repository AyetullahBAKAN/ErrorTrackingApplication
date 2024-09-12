namespace Core.Models
{
    public class MoneyType
    {
        public Guid MoneyTypeId { get; set; }
        public string TypeOfMoney { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public ICollection<Cost> Costs { get; set; }
    }
}
