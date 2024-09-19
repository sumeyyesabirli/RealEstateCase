using RealEstateCase.Core.Entities;
using RealEstateCase.Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateCase.Entity.Main
{
    public class Property : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double PropertyPrice { get; set; }
        public int AdvertisementStatusId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AdvertisementTypeId { get; set; }
        public AdvertisementType AdvertisementType { get; set; }
        public virtual ICollection<PropertyImage> Images { get; set; }
        public virtual PropertyDetails PropertyDetails { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }      
        public virtual AdvertisementStatus AdvertisementStatus { get; set; }

    }
} 
