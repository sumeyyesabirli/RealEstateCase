using RealEstateCase.Core.Enum;

namespace RealEstateCase.Business.Futures.Queries.Property.GetAllProperty
{
    public class GetAllPropertyQueryResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double PropertyPrice { get; set; }
        public int AdvertisementTypeId { get; set; }
        public int AdvertisementStatusId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }

        public PropertyDetailsQueryResponseModel? PropertyDetails { get; set; }
    }

    public class PropertyDetailsQueryResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Floors { get; set; }
        public int Garages { get; set; }
        public double Area { get; set; }
        public double Size { get; set; }
        public bool CenterCooling { get; set; }
        public bool Balcony { get; set; }
        public bool PetFriendly { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipPostalCode { get; set; }
        public string Neighborhood { get; set; }
    }
}
