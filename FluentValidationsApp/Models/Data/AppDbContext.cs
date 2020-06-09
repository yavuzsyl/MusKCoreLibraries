using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.Models.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        //options ile bu context.cs de kullanılacak sql provider belirtilecek ve varsa ek ayarlar
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
