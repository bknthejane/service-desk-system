using System.Threading.Tasks;
using Abp.Application.Services;
using Nthware.SDS.Authorization.Accounts.Dto;

namespace Nthware.SDS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
