using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCarManagement.Models;

namespace WebAppCarManagement.Data
{
    public class WebAppCarManagementContext : DbContext
    {
        public WebAppCarManagementContext (DbContextOptions<WebAppCarManagementContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppCarManagement.Models.Car> Car { get; set; } = default!;
    }
}
