using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CustomerDto : BaseDto
    {
        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string CustomerName { get; set; }
      
    }
}
