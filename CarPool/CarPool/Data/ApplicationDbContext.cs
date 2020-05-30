using System;
using System.Collections.Generic;
using System.Text;
using CarPool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarPool.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RouteUser>().HasKey(sc => new { sc.UserId, sc.RouteId });

            modelBuilder.Entity<RouteUser>()
                .HasOne<AppUser>(ru => ru.user)
                .WithMany(u => u.RouteUser)
                .HasForeignKey(ru => ru.UserId);
            modelBuilder.Entity<RouteUser>()
                .HasOne<Route>(ru => ru.Route)
                .WithMany(r => r.RouteUser)
                .HasForeignKey(ru => ru.RouteId);
        }
        public DbSet<Car> cars { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<RouteUser> routeUsers { get; set; }
        public DbSet<AppUser> users { get; set; }









    }
}
