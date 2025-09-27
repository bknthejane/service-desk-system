using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nthware.SDS.Authorization.Roles;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.MultiTenancy;

namespace Nthware.SDS.EntityFrameworkCore
{
    public class SDSDbContext : AbpZeroDbContext<Tenant, Role, User, SDSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SDSDbContext(DbContextOptions<SDSDbContext> options)
            : base(options)
        {
        }
    }
}
