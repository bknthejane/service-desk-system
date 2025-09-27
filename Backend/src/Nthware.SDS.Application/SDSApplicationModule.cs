using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nthware.SDS.Authorization;

namespace Nthware.SDS
{
    [DependsOn(
        typeof(SDSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SDSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SDSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SDSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
