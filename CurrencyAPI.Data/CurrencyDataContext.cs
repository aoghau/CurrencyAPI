using CurrencyAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Data
{
    public class CurrencyDataContext : DbContext, ICurrencyDataContext
    {
        public CurrencyDataContext(DbContextOptions<CurrencyDataContext> options) :base(options) 
        {
            Database.EnsureCreated();
        }

        public CurrencyDataContext() :base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=CurrencyDB;Port=5432;User Id=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<User> Users {  get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
