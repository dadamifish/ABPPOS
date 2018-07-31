using Microsoft.AspNetCore.Antiforgery;
using FT.POS.Controllers;

namespace FT.POS.Web.Host.Controllers
{
    public class AntiForgeryController : POSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
