using Data.Models;
using ExternalData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarPool.Data
{
    public class RoutesContext: DbContext
    {
   
        public DbSet<Route> Routes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=geography;User Id=postgres;Password=polav1994");

       


    }
}
