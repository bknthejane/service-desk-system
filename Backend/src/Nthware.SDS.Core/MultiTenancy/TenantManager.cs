using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.Editions;

namespace Nthware.SDS.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
