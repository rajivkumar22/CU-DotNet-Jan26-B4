using Yarp.ReverseProxy;

namespace SmartBank.GatewayApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowWebApp", policy =>
                {
                    policy.WithOrigins(
                            "https://localhost:7150",  // Web app HTTPS
                            "http://localhost:5266",   // Web app HTTP
                            "https://localhost:7003",  // Alternative HTTPS
                            "http://localhost:5000"    // Alternative HTTP
                        )
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            // ✅ Add Reverse Proxy
            builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

            var app = builder.Build();

            // ✅ Use CORS
            app.UseCors("AllowWebApp");

            // ✅ Add root endpoint
            app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>

<body>
    <h1>🏦 SmartBank API Gateway</h1>
    <p class='status'>✅ Gateway is running successfully!</p>
    
   
    
    
"));

            // ✅ Add health check endpoint
            app.MapGet("/health", () => Results.Ok(new
            {
                status = "Healthy",
                service = "SmartBank API Gateway",
                timestamp = DateTime.UtcNow,
                version = "1.0.0",
                routes = new
                {
                    auth = "https://localhost:7001",
                    accounts = "https://localhost:7002",
                    transactions = "https://localhost:7185"
                }
            }));

            // ✅ Map Proxy
            app.MapReverseProxy();

            app.Run();
        }
    }
}