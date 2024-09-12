using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class RootAnalysisDto : BaseDto
    {
        [Display(Name = "Sebep 1")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string WhyOne { get; set; }

        [Display(Name = "Sebep 2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string WhyTwo { get; set; }

        [Display(Name = "Sebep 3")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string WhyThree { get; set; }

        [Display(Name = "Kök Sebep")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string WhyRoot { get; set; }

        [Display(Name = "Çözüm")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Result { get; set; }
    }
}
