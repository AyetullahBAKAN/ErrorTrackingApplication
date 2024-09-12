using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class MontageLetterDto : BaseDto
    {
        [Display(Name = "Montaj No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string MontageNumber { get; set; }
       
    }
}
