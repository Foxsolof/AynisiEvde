using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AynısıEvde.Pages
{
    public class FoodBlueprintModel : BaseButtonedPageModel
    {
        public string Name { get; set; } = "";
        public string User { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string description = "";
        public void OnGet()
        {
            string emote = " \U0001f962 ";
            string currentTheme = Request.Cookies["theme"] ?? "light";
            if (currentTheme != "light")
            {
                emote = "🍽";
            }
            Name = "Doner";
            User = "Ali Efe SONMEZ!";
            Ingredients = "10 tane mavi kola \n 20 tane meybuz\n 1 döner ustası\nBir tutam da bilim";
            string new_ing = emote;
            for (int i = 0; i < Ingredients.Length; i++)
            {
                new_ing += Ingredients[i];
                if (Ingredients[i] == '\n')
                {
                    new_ing += emote;
                }
            }
            Ingredients = new_ing;
            description = "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz";
            string new_desc = "1. ";
            int count = 1;
            for(int i = 0; i < description.Length; i++)
            {
                new_desc += description[i];
                if (description[i] == '\n')
                {
                    count++;
                    new_desc += count.ToString()+". ";
                }
            }
            description = new_desc;
        }
        
    }
}
