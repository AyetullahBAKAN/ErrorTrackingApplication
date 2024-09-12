using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorSubGroupDto : BaseDto
    {
        [Display(Name = "Hata Alt Grup Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ErrorSubGroupName { get; set; }

    }
}
