using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPlayground.RazorPages.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "max.mustermann@seitenbau.com"),
                new Claim("FullName", "Max Mustermann"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            //principal.AddIdentity(new ClaimsIdentity(new List<Claim>() { new Claim()}));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}