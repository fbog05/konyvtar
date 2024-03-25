using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using konyvtar.Models;

namespace konyvtar.Data
{
    public class konyvtarContext : DbContext
    {
        public konyvtarContext (DbContextOptions<konyvtarContext> options)
            : base(options)
        {
        }

        public DbSet<konyvtar.Models.Kolcsonzesek> Kolcsonzesek { get; set; } = default!;

        public DbSet<konyvtar.Models.Kolcsonzok>? Kolcsonzok { get; set; }
    }
}
