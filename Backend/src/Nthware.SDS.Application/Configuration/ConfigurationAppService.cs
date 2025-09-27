using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Nthware.SDS.Configuration.Dto;

namespace Nthware.SDS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SDSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
