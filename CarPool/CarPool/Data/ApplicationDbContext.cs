using System;
using System.Collections.Generic;
using System.Text;
using CarPool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarPool.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
