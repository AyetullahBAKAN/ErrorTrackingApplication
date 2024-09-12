using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class SolutionAndStandardizitionDto : BaseDto
    {
        [Display(Name = "Geçici Çözüm")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string SolutionShort { get; set; }

        [Display(Name = "Kalıcı Çözüm")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string SolutionPerma { get; set; }

        [Display(Name = "Çözüm Detay")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string SolutionDetail { get; set; }

        [Display(Name = "Hata Nasıl Kapatıldı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string HowErrorClose { get; set; }

        [Display(Name = "Hata Kapapatılma Nedeni")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorClosingReasonId { get; set; }

        public virtual ErrorClosingReason? ErrorClosingReason { get; set; }
    }
}
