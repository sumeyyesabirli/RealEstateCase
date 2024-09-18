using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RealEstateCase.DataAccess.Contexts;
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
           // service.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<CafeMasterDbContext>));
            service.TryAddScoped<DbContext, RealEstateCaseDbContext>();
        }
    }
}
