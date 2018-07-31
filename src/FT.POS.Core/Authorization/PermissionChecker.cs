using Abp.Authorization;
using FT.POS.Authorization.Roles;
using FT.POS.Authorization.Users;

namespace FT.POS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
