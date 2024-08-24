using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PortalLatihan.Infrastructure.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PortalLatihanDBContext>
    {
        public PortalLatihanDBContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../PortalLatihan.API"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PortalLatihanDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new PortalLatihanDBContext(optionsBuilder.Options);
        }
    }
}
