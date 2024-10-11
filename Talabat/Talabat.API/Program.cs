
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.API.MiddleWare;
using Talabat.API.Profiless;
using Talabat.Core.Interfaces;
using Talabat.Core.Models;
using Talabat.Repository.Connections;
using Talabat.Repository.DataSeeding;
using Talabat.Repository.Repositories;

namespace Talabat.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddApplicationServices();
        builder.Services.AddDbContext<TalabatDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulfConnection")));
        var app = builder.Build();

        //{
        //    var services = scope.ServiceProvider;
        //    var dbcontext = services.GetRequiredService<TalabatDBContext>();
        //    await dbcontext.Database.MigrateAsync();
        //}
        //finally
        //{
        //    scope.Dispose();
        //}
        using var scope = app.Services.CreateScope();
		var services = scope.ServiceProvider;
		var dbcontext = services.GetRequiredService<TalabatDBContext>();
        var loggerfactory=services.GetRequiredService<ILoggerFactory>();
        try
        {
            await dbcontext.Database.MigrateAsync();
            await TalabatContextSeed.SeedAsync(dbcontext);
        }
        catch (Exception ex)
        {
            var logger = loggerfactory.CreateLogger<Program>();
            logger.LogError(ex, "An Error Occurred During Migration");
        }
        // Configure the HTTP request pipeline.
        app.UseMiddleware<ExceptionMiddleWare>();
		if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStatusCodePagesWithReExecute("/Errors/{0}");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseStaticFiles();

        app.Run();
    }
}
