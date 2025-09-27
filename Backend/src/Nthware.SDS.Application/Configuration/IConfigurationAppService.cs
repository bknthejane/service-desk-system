using System.Threading.Tasks;
using Nthware.SDS.Configuration.Dto;

namespace Nthware.SDS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
