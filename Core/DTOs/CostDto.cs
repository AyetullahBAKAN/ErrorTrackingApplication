using Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DTOs
{
    public class CostDto : BaseDto
    {
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Description { get; set; }

        [Display(Name = "Zaman")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public double Time { get; set; }

        [Display(Name = "Miktar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal Amount { get; set; } // miktar

        [Display(Name = "Alan Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? FieldId { get; set; }
        public virtual Field? Field { get; set; }

        [Display(Name = "Para Türü")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? MoneyTypeId { get; set; }
        public virtual MoneyType? MoneyType { get; set; }
    }
}
