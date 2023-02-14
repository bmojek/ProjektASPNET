using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class KsiazkiContext : DbContext
    {
        public KsiazkiContext (DbContextOptions<KsiazkiContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Ksiazki> Ksiazki { get; set; } = default!;
    }
}
