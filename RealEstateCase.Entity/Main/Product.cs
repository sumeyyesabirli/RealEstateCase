using RealEstateCase.Core.Entities;
using RealEstateCase.Core.Enum;

namespace RealEstateCase.Entity.Main
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public PropertyStatus Status { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> Images { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
} 
