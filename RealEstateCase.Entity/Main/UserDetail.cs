using RealEstateCase.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateCase.Entity.Main
{
    public class UserDetail : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Description { get; set; }
        public bool? Gender { get; set; } // 0 ise kadın 1 ise erkek

        public int UserId { get; set; }      
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
