using AynısıEvde.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AynısıEvde.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly testdatabase access_point;
        public RecipesController(testdatabase context)
        {
            access_point = context;
        }
        //get methodu çalıştığında
        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await access_point.recipe_List.Select(r => new
            {
                r.recipe_id,
                r.recipe_name,
                r.recipe,
                ingredients = access_point.recipe_Ingredient_List.Where(i => i.recipe_id == r.recipe_id)
                .Select(i => new
                {
                    name = i.ingredient!.ingredient_name,
                    amount = i.amount,
                    unit = i.ingredient.ingredient_unit
                }).ToList()}).ToListAsync();

            return Ok(recipes);
        }
    }
}