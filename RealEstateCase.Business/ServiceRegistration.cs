using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCase.Business.Futures.Commands.Property.AddProperty;
using RealEstateCase.Business.Futures.Setup;
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
            service.AddScoped<CreateDataService>();
            var createDataService = service.BuildServiceProvider().GetService<CreateDataService>();
            createDataService.CreateAdvertisementStatus().GetAwaiter().GetResult();
            createDataService.CreateCategories().GetAwaiter().GetResult();
        }

    }
}
