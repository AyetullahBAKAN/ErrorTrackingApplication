using Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DTOs
{
    public class UserDto : IdentityUser<Guid>
    {

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string? Name { get; set; }


        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string? SurName { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Browsable(false)]
        [ScaffoldColumn(false)]
        public Guid? CreatedById { get; set; }


        [Browsable(false)]
        [ScaffoldColumn(false)]
        [StringLength(200)]
        public string? CreatedName { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDate { get; set; }

        [Browsable(false)]
        [ScaffoldColumn(false)]
        public Guid? LastModifiedById { get; set; }

        [Browsable(false)]
        [ScaffoldColumn(false)]
        [StringLength(200)]
        public string? LastModifiedName { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string UserVerifyState { get; set; }   //Ayetullah ++  

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [NotMapped]
        public Guid RoleId { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
