using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AynısıEvde.Pages
{
    public class FoodBlueprintModel : PageModel
    {
        public string Name { get; set; } = "";
        public string User { get; set; } = "";
        public string description = "";
        public void OnGet()
        {
            Name = "Doner";
            User = "Ali Efe SONMEZ!";
            description = "10 tane mavi kola \n 20 tane meybuz\n 1 döner ustası\nBir tutam da bilim";
        }
        public IActionResult OnPostToggleTheme()
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

            
            return RedirectToPage();
        }
    }
}
