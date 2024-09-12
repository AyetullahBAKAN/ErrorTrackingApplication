namespace Core.Models
{
    public class Field : BaseEntity
    {
        public string FieldName { get; set; }
        public ICollection<Cost> Costs { get; set; }
    }
}
