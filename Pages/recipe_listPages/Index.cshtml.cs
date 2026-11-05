using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AynısıEvde.model;
using AynısıEvde.data;

namespace AynısıEvde.Pages.recipe_listPages;

public class IndexModel : PageModel
{
    private readonly testdatabase _context;

    public IndexModel(testdatabase context)
    {
        _context = context;
    }

    public IList<recipe_list> Recipe_list { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Recipe_list = await _context.recipes_table.ToListAsync();
    }
}
