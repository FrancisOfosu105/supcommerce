using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SupCommerce.Data.Data
{
    public class SupCommerceDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SupCommerceDbContext>
    {
        public SupCommerceDbContext CreateDbContext(string[] args)
        {
            var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            enviromentName = enviromentName ?? "Development";


            var configuration     = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{enviromentName}.json", reloadOnChange: true, optional: true)
                .Build();

            var dbBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration.GetConnectionString("SupCommerceConnStr");
            
            if(string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException(nameof(connectionString));

            dbBuilder.UseSqlServer(connectionString);
            

            return new SupCommerceDbContext(dbBuilder.Options);
        }
    }
}