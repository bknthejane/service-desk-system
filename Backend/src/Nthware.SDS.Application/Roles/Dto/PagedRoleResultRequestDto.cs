using Abp.Application.Services.Dto;

namespace Nthware.SDS.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

