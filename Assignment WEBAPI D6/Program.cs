
using Assignment_WEBAPI_D6.Models;
using Assignment_WEBAPI_D6.Repository;
using Assignment_WEBAPI_D6.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WEBAPI_D6
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
            builder.Services.AddDbContext<CompanyDbContext>(op=>op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            //builder.Services.AddScoped<GenericRepository<Employee>>();
            //builder.Services.AddScoped<GenericRepository<Department>>();
            builder.Services.AddScoped<UnitOfWork>();

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

            app.Run();
        }
    }
}
