using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vagabond.Api.Data;
using Vagabond.Api.Repositories;
using Vagabond.Api.Services;
using Vagabond.Api.Middleware;

namespace Vagabond.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<VagabondApiContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("VagabondApiContext")
                    ?? throw new InvalidOperationException("Connection string not found.")
                ));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
            builder.Services.AddScoped<IDestinationService, DestinationService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}