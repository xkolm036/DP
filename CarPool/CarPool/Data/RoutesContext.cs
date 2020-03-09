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
        public DbSet<IdentityUser> Users { get; set; }

        public DbSet<RouteUser> RouteUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=geography;User Id=postgres;Password=polav1994");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RouteUser>().HasKey(sc => new { sc.RoutId, sc.UserId });

            modelBuilder.Entity<RouteUser>()
                .HasOne<Route>(sc => sc.Route)
                .WithMany(s => s.RouteUser)
                .HasForeignKey(sc => sc.RoutId);


            modelBuilder.Entity<RouteUser>()
                .HasOne<AppUser>(sc => sc.user)
                .WithMany(s => s.RouteUser)
                .HasForeignKey(sc => sc.UserId);
        }


    }
}
