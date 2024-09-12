using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class PartDto : BaseDto
    {
        [Display(Name = "Parça No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string PartNo { get; set; }

    }
}
