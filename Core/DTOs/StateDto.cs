using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class StateDto : BaseDto
    {
        [Display(Name = "Durum")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string StateName { get; set; }
       
    }
}
