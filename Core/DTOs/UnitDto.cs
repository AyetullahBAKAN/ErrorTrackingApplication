using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class UnitDto : BaseDto
    {
        [Display(Name = "Birim Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string UnitName { get; set; }
    }
}
