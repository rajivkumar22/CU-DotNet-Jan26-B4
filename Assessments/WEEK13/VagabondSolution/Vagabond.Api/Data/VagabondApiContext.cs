using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vagabond.Api.Models;

namespace Vagabond.Api.Data
{
    public class VagabondApiContext : DbContext
    {
        public VagabondApiContext(DbContextOptions<VagabondApiContext> options)
            : base(options)
        {
        }

        public DbSet<Vagabond.Api.Models.Destination> Destinations { get; set; } = default!;
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>(entity =>
            {

                entity.Property(d => d.CityName)
                      .IsRequired();

                entity.Property(d => d.Country)
                      .IsRequired();

                entity.Property(d => d.Description)
                      .HasMaxLength(200);


                entity.Property(d => d.Rating)
                      .HasDefaultValue(3);


                
            });
        }
    }
}
