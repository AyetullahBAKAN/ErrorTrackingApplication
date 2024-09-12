using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorMainTitleDto : BaseDto
    {
        [Display(Name = "Hata Ana Başlık Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ErrorMainTitleName { get; set; }

    }
}
