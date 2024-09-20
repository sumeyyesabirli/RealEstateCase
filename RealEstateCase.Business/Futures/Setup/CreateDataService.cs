using Microsoft.EntityFrameworkCore;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.Business.Futures.Setup
{
    public class CreateDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAdvertisementStatus()
        {
            var hasData = await _unitOfWork.Repository<IAdvertisementStatusRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var advertisentments = new List<AdvertisementStatus>();
                advertisentments.Add(new AdvertisementStatus
                {
                    //Id = 1,
                    Code = "Pending"
                });
                advertisentments.Add(new AdvertisementStatus
                {
                    //  Id = 2,
                    Code = "Approve"
                });
                advertisentments.Add(new AdvertisementStatus
                {
                    //   Id = 3,
                    Code = "Cancelled"
                });
                advertisentments.Add(new AdvertisementStatus
                {
                    //    Id = 4,
                    Code = "Removed"
                });
                _unitOfWork.OpenTransaction();
                foreach (var advertisentment in advertisentments)
                {
                    _unitOfWork.Repository<IAdvertisementStatusRepository>().Add(advertisentment);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                }
                _unitOfWork.Commit();
            }

        }
        public async Task CreateAdvertisementType()
        {
            var hasData = await _unitOfWork.Repository<IAdvertisementTypeRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var advertisentments = new List<AdvertisementType>();
                advertisentments.Add(new AdvertisementType
                {
                    AdvertisementTypeName = "Satılık"
                });
                advertisentments.Add(new AdvertisementType
                {
                    AdvertisementTypeName = "Kiralık"
                });

                _unitOfWork.OpenTransaction();
                foreach (var advertisentment in advertisentments)
                {
                    _unitOfWork.Repository<IAdvertisementTypeRepository>().Add(advertisentment);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                }
                _unitOfWork.Commit();
            }
        }

        /*public async Task CreateUsers()
        {
            var hasData = await _unitOfWork.Repository<IUserRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var users = new List<User>();
                users.Add(new User
                {
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "hash1",
                    PasswordSalt = "salt1",
                    CreatedById = 1,
                    UpdatedById = 1,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true,
                }) ;
                users.Add(new User
                {
                    Username = "user1",
                    Email = "user1@example.com",
                    PasswordHash = "hash2",
                    PasswordSalt = "salt2",
                    CreatedById = 1,
                    UpdatedById = 1,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsActive = true,
                });

                _unitOfWork.OpenTransaction();
                try
                {
                    foreach (var user in users)
                    {
                        _unitOfWork.Repository<IUserRepository>().Add(user);
                    }

                    // Save changes once after adding all users
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }*/

        public async Task CreatePropertyAndDetails()
        {
            var hasData = await _unitOfWork.Repository<IPropertyRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var propertyList = new List<Property>
        {
            new Property
            {
                Title = "Luxury Villa",
                Description = "Beautiful villa with sea view",
                PropertyPrice = 4500000,
                UserId = 1,
                AdvertisementTypeId = 1, // Satılık
                AdvertisementStatusId = 1 // Onay bekliyor
            },
            new Property
            {
                Title = "Cozy Apartment",
                Description = "Modern apartment in the city center",
                PropertyPrice = 1200000, 
                UserId = 1, 
                AdvertisementTypeId = 2, // Kiralık
                AdvertisementStatusId = 1 // Onay bekliyor
            }
        };

                _unitOfWork.OpenTransaction();

                foreach (var property in propertyList)
                {
                    _unitOfWork.Repository<IPropertyRepository>().Add(property);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                    var propertyId = property.Id;
         
                    var propertyDetails = new PropertyDetails
                    {
                        Title = property.Title,
                        Description = property.Description,
                        Type = property.AdvertisementTypeId == 1 ? "Villa" : "Apartment", 
                        Status = property.AdvertisementTypeId == 1 ? "For Sale" : "For Rent",
                        Bedrooms = property.AdvertisementTypeId == 1 ? 4 : 2,
                        Bathrooms = property.AdvertisementTypeId == 1 ? 3 : 1,
                        Floors = property.AdvertisementTypeId == 1 ? 2 : 5,
                        Garages = property.AdvertisementTypeId == 1 ? 1 : 0,
                        Area = property.AdvertisementTypeId == 1 ? 4500 : 1200,
                        Size = property.AdvertisementTypeId == 1 ? 4500 : 1200,
                        CenterCooling = property.AdvertisementTypeId == 1,
                        Balcony = true,
                        PetFriendly = property.AdvertisementTypeId == 1,
                        Location = property.AdvertisementTypeId == 1 ? "Istanbul" : "Ankara",
                        Address = property.AdvertisementTypeId == 1 ? "123 Sea View Avenue" : "45 City Center Street",
                        Country = "Turkey",
                        City = property.AdvertisementTypeId == 1 ? "Istanbul" : "Ankara",
                        State = property.AdvertisementTypeId == 1 ? "Marmara" : "Anatolia",
                        ZipPostalCode = property.AdvertisementTypeId == 1 ? "34000" : "06000",
                        Neighborhood = property.AdvertisementTypeId == 1 ? "Seaside" : "City Center",
                        PropertyId = propertyId 
                    };

                    _unitOfWork.Repository<IPropertyDetailsRepository>().Add(propertyDetails);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                }

                _unitOfWork.Commit();
            }
        }

    }
}

