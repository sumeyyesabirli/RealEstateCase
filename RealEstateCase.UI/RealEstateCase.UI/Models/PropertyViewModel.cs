public class PropertyViewModel
{
    // Ana property bilgileri
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double PropertyPrice { get; set; }
    public int AdvertisementTypeId { get; set; }
    public int AdvertisementStatusId { get; set; }
    public int? UserId { get; set; } = 1;
    public bool  IsActive { get; set; }

    // Property detay bilgileri
    public PropertyDetailsViewModel? PropertyDetails { get; set; }
}

public class PropertyDetailsViewModel
{
    public string Title { get; set; } = "boş";
    public string Description { get; set; } = "boş";
    public string Type { get; set; }
    public string Status { get; set; }
    public string Location { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Floors { get; set; }
    public int Garages { get; set; }
    public double Area { get; set; }
    public double Size { get; set; }
    public bool CenterCooling { get; set; } = false;
    public bool Balcony { get; set; } = false;
    public bool PetFriendly { get; set; } = false;
    public string Address { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipPostalCode { get; set; }
    public string Neighborhood { get; set; }
}
