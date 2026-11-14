using AynısıEvde.data;
using AynısıEvde.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AynısıEvde.Pages
{
    public class testoneModel : BaseButtonedPageModel
    {
        private readonly testdatabase _context;

        public testoneModel(testdatabase context)
        {
            _context = context;
        }
        public IList<recipe_list> tarif_listesi { get; set; } = default!;
        public IList<ingredient_list> malzeme_listesi { get; set; } = default!;

        public async Task OnGetAsync() {
            tarif_listesi = await _context.recipes_table.ToListAsync();
            malzeme_listesi = await _context.malzemeler.ToListAsync();
        }

        public async Task OnPostAsync() {
        
        
        }

    }
}
