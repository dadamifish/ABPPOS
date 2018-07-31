using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FT.POS.Controllers
{
    public abstract class POSControllerBase: AbpController
    {
        protected POSControllerBase()
        {
            LocalizationSourceName = POSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
