using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class Favorite : BaseEntity
    {   
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
