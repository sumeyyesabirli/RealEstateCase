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
            if(!hasData.Any())
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
                foreach(var advertisentment in advertisentments)
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
        public async Task CreateProperties()
        {
            var hasData = await _unitOfWork.Repository<IPropertyRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var properties = new List<Property>();
                properties.Add(new Property
                {
                    Title = "Luxury Villa",
                    Description = "Beautiful villa with sea view",
                    PropertyPrice = 1200000,
                    UserId = 1,
                    AdvertisementTypeId = 1,
                    AdvertisementStatusId = 1
                });
                properties.Add(new Property
                {
                    Title = "Cozy Apartment",
                    Description = "Modern apartment in the city center",
                    PropertyPrice = 500000,
                    UserId = 1,
                    AdvertisementTypeId = 2,
                    AdvertisementStatusId = 2
                });

                _unitOfWork.OpenTransaction();
                foreach (var property in properties)
                {
                    _unitOfWork.Repository<IPropertyRepository>().Add(property);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                }
                _unitOfWork.Commit();
            }
        }
        public async Task CreatePropertyDetails()
        {
            var hasData = await _unitOfWork.Repository<IPropertyDetailsRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var propertyDetails = new List<PropertyDetails>();
                propertyDetails.Add(new PropertyDetails
                {
                    Title = "Luxury Villa",
                    Description = "Beautiful villa with sea view",
                    Bedrooms = 4,
                    Bathrooms = 3,
                    SaleOrRentPrice = 1200000,
                    Location = "Istanbul",
                    Country = "Turkey",
                    City = "Istanbul",
                    State = "Marmara",
                    ZipCode = "34000"
                });
                propertyDetails.Add(new PropertyDetails
                {
                    Title = "Cozy Apartment",
                    Description = "Modern apartment in the city center",
                    Bedrooms = 2,
                    Bathrooms = 1,
                    SaleOrRentPrice = 500000,
                    Location = "Ankara",
                    Country = "Turkey",
                    City = "Ankara",
                    State = "Anatolia",
                    ZipCode = "06000"
                });
                _unitOfWork.OpenTransaction();
                foreach (var propertyDetail in propertyDetails)
                {
                    _unitOfWork.Repository<IPropertyDetailsRepository>().Add(propertyDetail);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                }
                _unitOfWork.Commit();
            }
        }
    }
}
