using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AynısıEvde.Pages
{
    public class BaseButtonedPageModel:PageModel
    {
        public IActionResult OnPostToggleTheme(int? id)
        {

            string currentTheme = Request.Cookies["theme"] ?? "light";


            string newTheme = currentTheme == "light" ? "dark" : "light";


            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1), // 1 yıl boyunca silinmesin
                HttpOnly = true,
                IsEssential = true,
                Secure = false
            };
            Response.Cookies.Append("theme", newTheme, options);
            if (id.HasValue)
            {
                return RedirectToPage(new { id=id});
            }

            return RedirectToPage();
        }
    }
}
