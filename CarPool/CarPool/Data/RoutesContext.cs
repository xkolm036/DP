using CarPool.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<RouteUser> routeUsers { get; set; }

      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("Server=tcp:dpkolarik.database.windows.net,1433;Initial Catalog=Geography;Persist Security Info=False;User ID=mkolarik;Password=Polav1994!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



    }
}
