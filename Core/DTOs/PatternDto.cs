using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class PatternDto : BaseDto
    {
        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Display(Name = "Proje Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        [Display(Name = "Montaj No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid MontageLetterId { get; set; }
        public MontageLetter? MontageLetter { get; set; }

        [Display(Name = "Parça No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid PartId { get; set; }
        public Part? Part { get; set; }

        [Display(Name = "Operasyon No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid OperationId { get; set; }
        public Operation? Operation { get; set; }


    }
}

