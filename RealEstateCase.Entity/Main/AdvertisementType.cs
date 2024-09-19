using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class AdvertisementType : BaseEntity
    {
        public string AdvertisementTypeName { get; set; }
        public ICollection<Property> Propertys { get; set; }
    }
}
