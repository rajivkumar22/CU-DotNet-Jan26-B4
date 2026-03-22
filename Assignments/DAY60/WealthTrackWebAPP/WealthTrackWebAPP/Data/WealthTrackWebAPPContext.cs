using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WealthTrackWebAPP.Models;

namespace WealthTrackWebAPP.Data
{
    public class WealthTrackWebAPPContext : DbContext
    {
        public WealthTrackWebAPPContext (DbContextOptions<WealthTrackWebAPPContext> options)
            : base(options)
        {
        }

        public DbSet<WealthTrackWebAPP.Models.Investment> Investment { get; set; } = default!;
    }
}
