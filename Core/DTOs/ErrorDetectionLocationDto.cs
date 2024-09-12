using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorDetectionLocationDto : BaseDto
    {
        [Display(Name = "Hata Tespit Yeri")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ErrorLocation { get; set; }
    }
}
