namespace Core.Models
{
    public class Unit : BaseEntity
    {
        public string UnitName { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
