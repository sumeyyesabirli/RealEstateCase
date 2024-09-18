using Microsoft.EntityFrameworkCore;
using RealEstateCase.DataAccess.Repositories.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.Entity.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task CreateCategories()
        {
            var hasData = await _unitOfWork.Repository<ICategoryRepository>().Query().ToListAsync();
            if (!hasData.Any())
            {
                var advertisentments = new List<Category>();
                advertisentments.Add(new Category
                {
                    CategoryName = "Satılık"
                });
                advertisentments.Add(new Category
                {
                    CategoryName = "Kiralık"
                });
               
                _unitOfWork.OpenTransaction();
                foreach (var advertisentment in advertisentments)
                {
                    _unitOfWork.Repository<ICategoryRepository>().Add(advertisentment);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                }
                _unitOfWork.Commit();
            }
        }
    }
}
