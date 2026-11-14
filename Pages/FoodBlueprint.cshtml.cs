using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AynısıEvde.data;
using AynısıEvde.model;
using Microsoft.EntityFrameworkCore;

namespace AynısıEvde.Pages
{
    public class FoodBlueprintModel : BaseButtonedPageModel
    {
        public string Name { get; set; } = "";
        public string User { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string description = "";
        public string videourl = "";
        private readonly testdatabase db;
        public recipe_list rec;
        public List<ingredient_list> ing;
        public FoodBlueprintModel(testdatabase _db)
        {
            db = _db;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int targetid = id ?? 1;
            var rec = await db.recipes_table.FirstOrDefaultAsync(m => m.recipe_id == targetid);
            var ing = await db.recipe_Ingredient_List.Include(x => x.ingredient)
    .Where(x => x.recipe_id == targetid)
    .ToListAsync(); 
            if (rec is null)
            {
                return NotFound();
            }
            videourl = rec.recipe_video;
            string emote = " \U0001f962 ";
            string currentTheme = Request.Cookies["theme"] ?? "light";
            if (currentTheme != "light")
            {
                emote = "🍽";
            }
            emote = emote + " ";
            //Name = "Doner";
            Name = rec.recipe_name;
            User = "username";
            //Ingredients = "10 tane mavi kola \n 20 tane meybuz\n 1 döner ustası\nBir tutam da bilim";
            if (ing.Count > 0)
            {
                Ingredients = ing[0] .amount+" "+ ing[0].ingredient?.ingredient_unit+" "+ ing[0].ingredient?.ingredient_name;
                for (int i = 1; i < ing.Count; i++)
                {
                    Ingredients += "\n"+ ing[i].amount + " " + ing[i].ingredient?.ingredient_unit + " " + ing[i].ingredient?.ingredient_name;
                }
            }
            else
            {
                Ingredients = "Malzemeleri kendiniz anlayın";
            }
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
            description = rec.recipe;
            //description = "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz";
            string new_desc = "1. ";
            int count = 1;
            for (int i = 0; i < description.Length; i++)
            {
                new_desc += description[i];
                if (description[i] == '\n')
                {
                    count++;
                    new_desc += count.ToString() + ". ";
                }
            }
            description = new_desc;
            return Page();
        }
        public void OnLGet()
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
