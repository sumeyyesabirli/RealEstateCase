using RealEstateCase.Core.Entities;
using RealEstateCase.Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateCase.Entity.Main
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsApproved { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }       
    
    }
} 
