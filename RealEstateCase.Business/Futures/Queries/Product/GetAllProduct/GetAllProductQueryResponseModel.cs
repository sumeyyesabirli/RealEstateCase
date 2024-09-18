using RealEstateCase.Core.Enum;

namespace RealEstateCase.Business.Futures.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public ProductDetailsQueryResponseModel ProductDetails { get; set; }
    }

    public class ProductDetailsQueryResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Floors { get; set; }
        public int Garages { get; set; }
        public int Area { get; set; }
        public int Size { get; set; }
        public double SaleOrRentPrice { get; set; }
        public string BeforePriceLabel { get; set; }
        public string AfterPriceLabel { get; set; }
        public bool CenterCooling { get; set; }
        public bool Balcony { get; set; }
        public bool PetFriendly { get; set; }
        public bool Barbeque { get; set; }
        public bool FireAlarm { get; set; }
        public bool ModernKitchen { get; set; }
        public bool Storage { get; set; }
        public bool Dryer { get; set; }
        public bool Heating { get; set; }
        public bool Pool { get; set; }
        public bool Laundry { get; set; }
        public bool Sauna { get; set; }
        public bool Gym { get; set; }
        public bool Elevator { get; set; }
        public bool DishWasher { get; set; }
        public bool EmergencyExit { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
    }
}
