using Core.Models;
using System.ComponentModel.DataAnnotations;


namespace Core.DTOs
{
    public class ErrorTypeDto : BaseDto
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        [Display(Name = "Hata Detay Grubu")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorDetailGroupId { get; set; }
        public virtual ErrorDetailGroup? ErrorDetailGroup { get; set; }

        [Display(Name = "Hata Alt Grubu")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorSubGroupId { get; set; }
        public virtual ErrorSubGroup? ErrorSubGroup { get; set; }

        [Display(Name = "Hata Ana Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public Guid ErrorMainTitleId { get; set; }
        public virtual ErrorMainTitle? ErrorMainTitle { get; set; }
    }
}
