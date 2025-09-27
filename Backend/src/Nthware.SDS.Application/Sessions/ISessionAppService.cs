using System.Threading.Tasks;
using Abp.Application.Services;
using Nthware.SDS.Sessions.Dto;

namespace Nthware.SDS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
