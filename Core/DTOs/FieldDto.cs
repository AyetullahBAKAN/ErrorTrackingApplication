using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class FieldDto : BaseDto
    {
        [Display(Name = "Alan Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string FieldName { get; set; }
    }
}
