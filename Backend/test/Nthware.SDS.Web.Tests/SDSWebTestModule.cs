using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nthware.SDS.EntityFrameworkCore;
using Nthware.SDS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Nthware.SDS.Web.Tests
{
    [DependsOn(
        typeof(SDSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SDSWebTestModule : AbpModule
    {
        public SDSWebTestModule(SDSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SDSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SDSWebMvcModule).Assembly);
        }
    }
}