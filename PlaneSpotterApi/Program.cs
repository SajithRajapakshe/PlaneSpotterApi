
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlaneSpotterApi.Extensions;
using PlaneSpotterBL.Mappers;
using PlaneSpotterBL.Services;
using PlaneSpotterDL;
using PlaneSpotterDL.Repositories.AircraftRepository;
using System.Runtime.Serialization;

namespace PlaneSpotterApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DB context initializing
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContextFactory<DBContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
                opt.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient);

            //Register mappers, custom services and cors using separate static classes.
            //Extending functionality of the DI Container in service extension classes.
            builder.Services.AddObjectMappereExtension();
            builder.Services.AddCustomServiceExtension();
            builder.Services.AddCorsExtension();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //Run migration scripts
            app.Services.GetService<DBContext>().Database.Migrate();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}