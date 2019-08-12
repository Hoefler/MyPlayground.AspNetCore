using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPlayground.RazorPages.Controller
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Login()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();
            //principal.AddIdentity(new ClaimsIdentity(new List<Claim>() { new Claim()}));


            await HttpContext.SignInAsync("Test", principal);
        }
    }
}