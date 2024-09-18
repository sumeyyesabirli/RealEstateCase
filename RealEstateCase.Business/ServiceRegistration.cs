using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCase.Business.Futures.Commands.Product.AddProduct;
using System.Reflection;

namespace RealEstateCase.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegister(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblyContaining<Validation>();
            });
        }
    }
}
