using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Nthware.SDS.Controllers
{
    public abstract class SDSControllerBase: AbpController
    {
        protected SDSControllerBase()
        {
            LocalizationSourceName = SDSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
