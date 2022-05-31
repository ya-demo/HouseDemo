using HouseDemo.DataAccess.EntityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HouseDemo.DataAccess;
public class Program
{
    public static void Main(string[] args)
    {
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HouseDbContext>
    {
        public HouseDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            var cnStr = config.GetConnectionString("MsSql");
            if (string.IsNullOrEmpty(cnStr)) throw new ApplicationException("Missing .config connection string [MsSql]");
            var ctxBuilder = new DbContextOptionsBuilder<HouseDbContext>();
            ctxBuilder.UseSqlServer(cnStr);
            return new HouseDbContext(ctxBuilder.Options);
        }
    }
}