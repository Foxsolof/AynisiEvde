using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AynısıEvde.model;
using AynısıEvde.data;

namespace AynısıEvde.Pages.recipe_listPages;

public class CreateModel : PageModel
{
    private readonly testdatabase _context;

    public CreateModel(testdatabase context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public recipe_list Recipe_list { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.recipes_table.Add(Recipe_list);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
