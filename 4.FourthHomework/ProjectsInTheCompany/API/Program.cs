using Microsoft.EntityFrameworkCore;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Infrastructure;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ProjectsInTheCompany");

            builder.Services.AddDbContext<ProjectsCompanyDbContext>(db => db.UseSqlServer(connectionString,
                db => db.MigrationsAssembly("ProjectsInTheCompany.API")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructure();
            builder.Services.AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}