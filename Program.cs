using HanaGuro2.Data;
using HanaGuro2.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace HanaGuro2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddAuthorization();
        
        //+ DB Service
        builder.Services.AddDbContext<PlantDbContext>(options => 
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // migrate DB
        using (var ss = app.Services.CreateScope())
        {
            var services = ss.ServiceProvider;
            var context = services.GetService<PlantDbContext>();
            context?.Database.Migrate();
        }
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Settings
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        
        // Endpoints
        app.MapBiomeEndpoints();
        app.MapUserEndpoints();
        app.MapPlantBaseEndpoints();
        
        

        //app.UseAuthorization();
        
        app.Run();
    }
}