using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RealEstateCase.DataAccess.Contexts;
using RealEstateCase.DataAccess.UnitOfWork.Abstract;
using RealEstateCase.DataAccess.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateCase.DataAccess
{
    public static class ServiceRegistration
    {
        public static void DataAccessRegistration(this IServiceCollection service, IConfiguration configuration)
        {           
            service.AddDbContext<RealEstateCaseDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("connectionString"));
            });
            service.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<RealEstateCaseDbContext>));
            service.TryAddScoped<DbContext, RealEstateCaseDbContext>();
        }
    }
}
