using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }


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
    }
}
