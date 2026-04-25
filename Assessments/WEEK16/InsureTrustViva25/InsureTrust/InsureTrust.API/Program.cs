using System.Text;
using InsureTrust.API.Data;
using InsureTrust.API.Exceptions;
using InsureTrust.API.Helpers;
using InsureTrust.API.Repositories;
using InsureTrust.API.Services;
using InsureTrust.API.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using FluentValidation;
using FluentValidation.AspNetCore;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Allow disabling HTTPS locally for testing (set env var DISABLE_HTTPS=true)
var disableHttps = string.Equals(Environment.GetEnvironmentVariable("DISABLE_HTTPS"), "true", StringComparison.OrdinalIgnoreCase);

// Helper to find an available port on localhost (development convenience)
int GetAvailablePort(int start)
{
    for (int port = start; port < start + 1000; port++)
    {
        try
        {
            var listener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Loopback, port);
            listener.Start();
            listener.Stop();
            return port;
        }
        catch { }
    }
    return start;
}

// If ASPNETCORE_URLS not provided, bind to free ports starting at 7000/7001
if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ASPNETCORE_URLS")))
{
    var httpPort = GetAvailablePort(7000);
    if (!disableHttps)
    {
        var httpsPort = GetAvailablePort(7001);
        builder.WebHost.UseUrls($"http://localhost:{httpPort};https://localhost:{httpsPort}");
    }
    else
    {
        // Bind to HTTP only when DISABLE_HTTPS=true
        builder.WebHost.UseUrls($"http://localhost:{httpPort}");
    }
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InitiatePaymentDtoValidator>();

// Swagger with JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InsureTrust API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Enter: Bearer {token}",
        Name = "Authorization", In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey, Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
});

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT
var jwtKey = builder.Configuration["Jwt:Key"]!;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

// CORS for MVC frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVC", policy =>
        policy.WithOrigins(
            "https://localhost:7001", "http://localhost:7000",
            "https://localhost:5101", "http://localhost:5100",
            "https://localhost:5001", "http://localhost:5000")
              .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
});

// DI
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();
// Development auth bypass middleware (only active in Development)
app.UseMiddleware<InsureTrust.API.Middleware.DevAuthMiddleware>();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!disableHttps)
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseCors("AllowMVC");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Auto-migrate on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
