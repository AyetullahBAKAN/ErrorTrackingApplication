using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ErrorCardDto : BaseDto
    {
        [Display(Name = "Sayfa No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int PageNumber { get; set; }

        [Display(Name = "Form No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string FormNumber { get; set; }

        [Display(Name = "Rev No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int RevNumber { get; set; }
   
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        [Display(Name = "Kalıp")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? PatternId { get; set; }
        public PatternDto? Pattern { get; set; }

        [Display(Name = "Hata Tanımı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? ErrorDefineId { get; set; }
        public ErrorDefine? ErrorDefine { get; set; }

        [Display(Name = "Hata Sınıfı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? ErrorClassId { get; set; }
        public ErrorClass? ErrorClass { get; set; }

        [Display(Name = "Kök Analiz")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? RootAnalysisId { get; set; }
        public RootAnalysis? RootAnalysis { get; set; }

        [Display(Name = "Çözüm ve Standartlaştırma")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? SolutionAndStandardizitionId { get; set; }
        public SolutionAndStandardizition? SolutionAndStandardizition { get; set; }

        [Display(Name = "Maliyet")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? CostId { get; set; }
        public Cost? Cost { get; set; }

        [Display(Name = "Hata Tespit Yeri")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? ErrorDetectionLocationId { get; set; }
        public ErrorDetectionLocation? ErrorDetectionLocation { get; set; }

        [Display(Name = "Birim Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? UnitId { get; set; }
        public Unit? Unit { get; set; }

        [Display(Name = "Durum")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid? StateId { get; set; }
        public State?  States { get; set; }
    }
}
