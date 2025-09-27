using Abp.Application.Services;
using Nthware.SDS.MultiTenancy.Dto;

namespace Nthware.SDS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

