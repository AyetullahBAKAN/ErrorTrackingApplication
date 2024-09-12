using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class OperationDto : BaseDto
    {
        [Display(Name = "Operasyon No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string OperationNo { get; set; }

    }
}
