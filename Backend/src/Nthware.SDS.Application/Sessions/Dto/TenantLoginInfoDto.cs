using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nthware.SDS.MultiTenancy;

namespace Nthware.SDS.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
