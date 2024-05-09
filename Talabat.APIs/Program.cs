using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Errors;
using Talabat.APIs.Extenstions;
using Talabat.APIs.Helper;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerServices();
        builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddApplicationServices();
                


        var app = builder.Build();
        using var Scope = app.Services.CreateScope();
        var Services = Scope.ServiceProvider;

        var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
        try
        {
            var DbContext = Services.GetRequiredService<StoreContext>();
            await DbContext.Database.MigrateAsync();
            //DataSeeding
            await StoreContextSeed.SeedAsync(DbContext);
        }
        catch (Exception ex)
        {
            var Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogError(ex, "An Error Occured During Appling The Migration");
        }
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerMiddlewares();
        }

        app.UseStatusCodePagesWithReExecute("/error/{0}");
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}