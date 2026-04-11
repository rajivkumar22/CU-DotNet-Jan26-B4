using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using WebFluentAPI.Models;

namespace WebFluentAPI.Data
{
    public class WebFluentAPIContext : DbContext
    {
        public WebFluentAPIContext (DbContextOptions<WebFluentAPIContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelTest>()
      .Property(p => p.Id)
      .ValueGeneratedNever();

            modelBuilder.Entity<ModelTest>()
      .Property(p => p.Name)
      .IsRequired(true);
            modelBuilder.Entity<ModelTest>()
 .Property(p => p.Role)
 .IsRequired(true);

        }
        public DbSet<WebFluentAPI.Models.ModelTest> ModelTest { get; set; } = default!;
    }
}
