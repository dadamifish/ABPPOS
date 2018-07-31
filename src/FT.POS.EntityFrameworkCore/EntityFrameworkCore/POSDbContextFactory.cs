using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FT.POS.Configuration;
using FT.POS.Web;

namespace FT.POS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class POSDbContextFactory : IDesignTimeDbContextFactory<POSDbContext>
    {
        public POSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<POSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            POSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(POSConsts.ConnectionStringName));

            return new POSDbContext(builder.Options);
        }
    }
}
