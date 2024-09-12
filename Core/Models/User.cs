using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? Name { get; set; }
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
        public string UserVerifyState { get; set; } = "Beklemede"; 

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<ErrorType> ErrorTypes { get; set; }
        public ICollection<ErrorCard> ErrorCards { get; set; }


    }
}
