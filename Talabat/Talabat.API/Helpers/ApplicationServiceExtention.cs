using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;
using Talabat.API.Profiless;
using Talabat.Core.Interfaces;
using Talabat.Repository.Connections;
using Talabat.Repository.Repositories;

namespace Talabat.API.Helpers
{
    public static class ApplicationServiceExtention
    {
        public static void AddApplicationServices(this IServiceCollection Services) 
        {
           Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();
           Services.AddSwaggerGen();
            //builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<Product>>();
            //builder.Services.AddScoped<IGenaricRepository<ProductBrand>, GenaricRepository<ProductBrand>>();
            //builder.Services.AddScoped<IGenaricRepository<ProductType>, GenaricRepository<ProductType>>();
            Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
            Services.AddAutoMapper(typeof(Profiles));
            Services.Configure<ApiBehaviorOptions>(
                option =>
                {
                    option.InvalidModelStateResponseFactory = (ActionContext) =>
                    {
                        var response = new ValidationError()
                        {
                            Errors = ActionContext.ModelState.Where(e => e.Value.Errors.Count() > 0)
                                                   .SelectMany(e => e.Value.Errors)
                                                   .Select(e => e.ErrorMessage).ToList()
                        };
                        return new BadRequestObjectResult(response);
                    };
                });
            // Add services to the container.
        }
    }
}
