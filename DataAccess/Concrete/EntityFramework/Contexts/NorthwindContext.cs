using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (connectionString: @"Server=DESKTOP-AFN4BD5;Initial Catalog=Northwind; User ID=sa;Password=12345");
            //<add name="Cnn2" connectionString="Data Source=DESKTOP-33NDNJ7\SQLEXPRESS;Initial Catalog=EsnafSeninleDB;User ID=sa;Password=B!arge2018" providerName="System.Data.SqlClient" />
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
