using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Nthware.SDS.EntityFrameworkCore
{
    public static class SDSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SDSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SDSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
