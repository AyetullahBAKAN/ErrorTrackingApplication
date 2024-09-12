using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorDetailGroupDto : BaseDto
    {
        [Display(Name = "Hata Detay Grup İsmi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ErrorDetailGroupName { get; set; }

    }
}
