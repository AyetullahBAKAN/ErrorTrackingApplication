using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorClosingReasonDto : BaseDto
    {
        [Display(Name = "Hata Kapatılma Nedeni")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Reason { get; set; }
    }
}
