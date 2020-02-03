using System;
using CarPool.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

[assembly: HostingStartup(typeof(CarPool.Areas.Identity.IdentityHostingStartup))]
namespace CarPool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                var connBuilder = new NpgsqlConnectionStringBuilder(
                    context.Configuration.GetConnectionString("CarPoolUsers"));
       

                services.AddDbContext<CarPoolContext>(options =>
                    options.UseNpgsql(connBuilder.ConnectionString));

            });
        }
    }
}