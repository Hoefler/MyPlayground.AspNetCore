using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPlayground.RazorPages.Pages
{
    //[Authorize]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            Thread.Sleep(5000);
        }
    }
}