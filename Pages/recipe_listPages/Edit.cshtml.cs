using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AynısıEvde.model;
using AynısıEvde.data;

namespace AynısıEvde.Pages.recipe_listPages;

public class EditModel : PageModel
{
    private readonly testdatabase _context;

    public EditModel(testdatabase context)
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

        var recipe_list = await _context.recipe_List.FirstOrDefaultAsync(m => m.recipe_id == recipe_id);
        if (recipe_list is null)
        {
            return NotFound();
        }
        Recipe_list = recipe_list;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Recipe_list).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!recipe_listExists(Recipe_list.recipe_id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool recipe_listExists(int recipe_id)
    {
        return _context.recipe_List.Any(e => e.recipe_id == recipe_id);
    }
}
