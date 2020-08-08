using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Data.EF
{
    class CoreDBContextFactory : IDesignTimeDbContextFactory<CoreDBContext>
    {
        public CoreDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuration.GetConnectionString("CoreDB");
            var optionsBuilder = new DbContextOptionsBuilder<CoreDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CoreDBContext(optionsBuilder.Options);
        }
    }
}
