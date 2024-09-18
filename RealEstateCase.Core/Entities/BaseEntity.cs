using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RealEstateCase.Core.Entities
{
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
    }
}
