namespace Core.Models
{
    public class State : BaseEntity
    {
        public string StateName { get; set; }

        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
