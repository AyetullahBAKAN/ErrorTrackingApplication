namespace Core.Models
{
    public class Pattern : BaseEntity
    {

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        public Guid MontageLetterId { get; set; }
        public MontageLetter? MontageLetter { get; set; }

        public Guid PartId { get; set; }
        public Part? Part { get; set; }

        public Guid OperationId { get; set; }
        public Operation? Operation { get; set; }

        public ICollection<ErrorCard> ErrorCards { get; set; }
    }
}
