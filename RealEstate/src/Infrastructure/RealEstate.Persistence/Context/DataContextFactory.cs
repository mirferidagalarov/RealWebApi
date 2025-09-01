using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistence.Context
{
    internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();

            var cfg = new DbContextOptionsBuilder()
                         .UseSqlServer(config.GetConnectionString("cString"), sqlServerOptions =>
                         {
                             sqlServerOptions.CommandTimeout(15);
                             sqlServerOptions.MigrationsHistoryTable("MigrationsHistory");
                         });

            return new DataContext(cfg.Options);
        }
    }
}
