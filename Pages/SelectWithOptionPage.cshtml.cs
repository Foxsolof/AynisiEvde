using AynısıEvde.data;
using AynısıEvde.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AynısıEvde.Pages
{
    public class SelectWithOptionPageModel : BaseButtonedPageModel
    {
        private readonly testdatabase _context;

        public SelectWithOptionPageModel(testdatabase context)
        {
            _context = context;
        }

        public IList<recipe_list> Recipe_list { get; set; } = default!;
        public IList<recipe_ingredient_list> Recipe_inglist { get; set; } = default!;
        public IList<ingredient_list> ing_list { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int? Selected { get; set; }
        [BindProperty(SupportsGet = true)]
        public String? SelectedName { get; set; }
        public IList<recipe_list> query { get; set; } = default!;
        //sayfa açıldığında ve güncellendiğinde?
        public async Task OnGetAsync()
        {
            SelectedName=SelectedName ?? "";
            Recipe_inglist = await _context.recipe_Ingredient_List.ToListAsync();
            ing_list = await _context.malzemeler.ToListAsync();
            if (Selected.HasValue && Selected > 0)
            {
                // Önce hangi tariflerin id'sinin seçtiğimiz aramaya uygun onu bul
                var matchingRecipeIds = _context.recipe_Ingredient_List
                    .Where(ri => ri.ingredient_id == Selected)
                    .Select(ri => ri.recipe_id);

                // Tarif idleri listesinin hangileri varsa onları listele
                Recipe_list = await _context.recipes_table.Where(r => (matchingRecipeIds.Contains(r.recipe_id) )).Where(e=> e.recipe_name.ToUpper().Contains(SelectedName.ToUpper())).ToListAsync();
            }
            else
            {
                Recipe_list = await _context.recipes_table.Where(e => e.recipe_name.ToUpper().Contains(SelectedName.ToUpper())).ToListAsync();
            }
        }
    }
}
