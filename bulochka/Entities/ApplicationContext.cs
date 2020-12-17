using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bulochka.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Bulochka> Bulochka { get; set; }
        public DbSet<BulochkaTypes> BulochkaTypes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
