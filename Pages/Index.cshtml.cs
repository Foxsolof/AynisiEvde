using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AynısıEvde.Pages
{
    public class IndexModel : PageModel
    {
        public string teststr1 { get; set; }
        public void OnGet()
        {
            teststr1 = "video title 1";
        }
    }
}
