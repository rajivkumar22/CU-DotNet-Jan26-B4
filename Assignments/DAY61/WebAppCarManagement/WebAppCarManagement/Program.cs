using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppCarManagement.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppCarManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebAppCarManagementContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppCarManagementContext") ?? throw new InvalidOperationException("Connection string 'WebAppCarManagementContext' not found.")));

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
             .AddRoles<IdentityRole>() 
              .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");
            app.MapRazorPages();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                string[] roles = { "Admin", "Customer", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

                // Create Admin
                var admin = new IdentityUser { UserName = "admin@test.com", Email = "admin@test.com" };
                if (await userManager.FindByEmailAsync(admin.Email) == null)
                {
                    await userManager.CreateAsync(admin, "Admin@123");
                    await userManager.AddToRoleAsync(admin, "Admin");
                }

                // Customer
                var customer = new IdentityUser { UserName = "customer@test.com", Email = "customer@test.com" };
                if (await userManager.FindByEmailAsync(customer.Email) == null)
                {
                    await userManager.CreateAsync(customer, "Customer@123");
                    await userManager.AddToRoleAsync(customer, "Customer");
                }

                // Normal User
                var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com" };
                if (await userManager.FindByEmailAsync(user.Email) == null)
                {
                    await userManager.CreateAsync(user, "User@123");
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

            app.Run();
        }
    }
}
