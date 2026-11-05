using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AynısıEvde.model;
using AynısıEvde.data;

namespace AynısıEvde.Pages.recipe_listPages;

public class DeleteModel : PageModel
{
    private readonly testdatabase _context;

    public DeleteModel(testdatabase context)
    {
        _context = context;
    }

    [BindProperty]
    public recipe_list Recipe_list { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? recipe_id)
    {
        if (recipe_id is null)
        {
            return NotFound();
        }

        var recipe_list = await _context.recipes_table.FirstOrDefaultAsync(m => m.recipe_id == recipe_id);
        if (recipe_list is null)
        {
            return NotFound();
        }
        else
        {
            Recipe_list = recipe_list;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? recipe_id)
    {
        if (recipe_id is null)
        {
            return NotFound();
        }

        var recipe_list = await _context.recipes_table.FindAsync(recipe_id);
        if (recipe_list != null)
        {
            Recipe_list = recipe_list;
            _context.recipes_table.Remove(Recipe_list);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
