using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class AdvertisementStatus: BaseEntity
    {
        public string Code { get; set; }
        public string? Description { get; set; }
    }
}
