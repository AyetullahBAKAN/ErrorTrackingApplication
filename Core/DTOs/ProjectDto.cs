using Core.Models;
using System.ComponentModel.DataAnnotations;
namespace Core.DTOs
{
    public class ProjectDto : BaseDto
    {
        [Display(Name = "Proje Ado")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ProjectName { get; set; }

        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
