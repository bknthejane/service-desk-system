using Abp.Authorization;
using Nthware.SDS.Authorization.Roles;
using Nthware.SDS.Authorization.Users;

namespace Nthware.SDS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
