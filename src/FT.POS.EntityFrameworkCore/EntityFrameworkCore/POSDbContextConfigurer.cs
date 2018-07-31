using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FT.POS.EntityFrameworkCore
{
    public static class POSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<POSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<POSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
