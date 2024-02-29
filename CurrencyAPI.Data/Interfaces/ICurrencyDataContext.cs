using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Data.Interfaces
{
    public interface ICurrencyDataContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<User> Users { get; set; }
        public int SaveChanges();
        
    }
}
