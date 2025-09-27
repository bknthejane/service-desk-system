using Abp.MultiTenancy;
using Nthware.SDS.Authorization.Users;

namespace Nthware.SDS.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
