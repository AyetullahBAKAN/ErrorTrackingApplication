namespace Core.DTOs
{
    public class BaseDto
    {
        public Guid? Id { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid? CreatedById { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? LastModifiedById { get; set; }

        public string? LastModifiedName { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public bool? IsActive { get; set; } = true;
    }
}
