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
    }
}
