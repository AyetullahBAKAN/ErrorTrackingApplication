using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorDefineDto : BaseDto
    {
        [Display(Name = "Hata Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ErrorExplain { get; set; }
    }
}
