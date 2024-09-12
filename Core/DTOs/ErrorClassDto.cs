using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorClassDto : BaseDto
    {
        [Display(Name = "Kısa Detay")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string ShortDetail { get; set; }

        [Display(Name = "Hata Ana Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorMainTitleId { get; set; }
        public ErrorMainTitle? ErrorMainTitle { get; set; }

        [Display(Name = "Hata Alt Grup")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorSubGroupId { get; set; }
        public ErrorSubGroup? ErrorSubGroup { get; set; }
    }
}
