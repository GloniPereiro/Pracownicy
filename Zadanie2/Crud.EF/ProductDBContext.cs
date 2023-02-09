using Crud.domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EF
{
    public class ProductDBContext : DbContext
    {
        public DbSet<ListaPracownikow> ListaPracownikow { get; set; }
        public DbSet<ListaZadan> ListaZadan { get; set; }
        public ProductDBContext()
        {

        }

        public ProductDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaPracownikow>().HasKey(e => e.IdPracownika);
            modelBuilder.Entity<ListaZadan>().HasKey(s => s.IdZadania);
        }
    }
}
 