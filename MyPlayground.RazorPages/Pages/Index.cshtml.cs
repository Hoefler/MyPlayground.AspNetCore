using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPlayground.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> Messages = new List<string>();
        public void OnGet()
        {
            Messages = new List<string> {"Message1", "Message2"};
        }
    }
}
