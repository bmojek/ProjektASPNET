using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class KsiazkiDbContex : DbContext
    {
        public KsiazkiDbContex(DbContextOptions<KsiazkiDbContex> options) :
       base(options)
        {
        }

        public DbSet<Ksiazki> Ksiazkis
        {
            get; set;
        }
    }
}