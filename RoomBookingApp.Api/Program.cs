using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Persistence;
using RoomBookingApp.Persistence.Repositories;

namespace RoomBookingApp.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RoomBookingApp.Api", Version = "v1" });
        });


        var connString = "DataSource=:memory:";
        var conn = new SqliteConnection(connString);
        conn.Open();

        builder.Services.AddDbContext<RoomBookingAppDbContext>(opt => opt.UseSqlite(conn));

        builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
        builder.Services.AddScoped<IRoomBookingRequestProcessor, RoomBookingRequestProcessor>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<RoomBookingAppDbContext>();
        try
        {
            context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            //logger.LogError(ex, "An error occured during migration");
        }

        app.Run();
    }
}
