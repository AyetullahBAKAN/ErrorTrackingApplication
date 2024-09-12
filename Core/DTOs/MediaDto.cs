using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class MediaDto : BaseDto
    {
        [Display(Name = "Dosya Yolu")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ImagePath { get; set; }
    }
}
