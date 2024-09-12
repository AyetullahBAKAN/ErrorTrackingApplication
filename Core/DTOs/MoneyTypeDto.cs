using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class MoneyTypeDto
    {
        [Display(Name = "Para Türü")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid MoneyTypeId { get; set; }
        public string TypeOfMoney { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid? CreatedById { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? LastModifiedById { get; set; }

        public string? LastModifiedName { get; set; }

        public bool IsDeleted { get; set; } =false;

        public bool IsActive { get; set; }= true;
    }
}
