using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebFluentAPI.Data;

namespace WebFluentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add database context
            builder.Services.AddDbContext<WebFluentAPIContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("WebFluentAPIContext")));

            // Add controller support
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebFluentAPI",
                    Version = "v1",
                    Description = "ASP.NET Core Web API with Entity Framework and Swagger"
                });
            });

            var app = builder.Build();

            // Configure middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebFluentAPI v1");
                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
