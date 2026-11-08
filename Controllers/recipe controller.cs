using AynısıEvde.data;
using AynısıEvde.model;
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
            var recipes = await access_point.recipes_table.Select(r => new
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
        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeRequest request)
        {
            // recipe list oluşturma
            var newRecipe = new recipe_list
            {
                recipe_name = request.recipe_name,
                recipe = request.recipe,
                recipe_video = request.recipe_video??"",
                approval = false
            };

            access_point.recipes_table.Add(newRecipe);
            await access_point.SaveChangesAsync();

            // Gönderilen malzemeleri veritabanında bul
            foreach (var item in request.ingredients)
            {
                var ingredient = await access_point.malzemeler
                    .FirstOrDefaultAsync(i => i.ingredient_name == item.name
                                           && i.ingredient_unit == item.unit);

                // hata kontrol
                if (ingredient == null)
                    return BadRequest($"HATA,MALZEME YOK: {item.name}");

                access_point.recipe_Ingredient_List.Add(
                    new recipe_ingredient_list
                    {
                        recipe_id = newRecipe.recipe_id,
                        ingredient_id = ingredient.ingredient_id,
                        amount = item.amount
                    });
            }

            await access_point.SaveChangesAsync();

            return Ok(new
            {
                message = "Tarif başarıyla eklendi.",
                recipe_id = newRecipe.recipe_id
            });
        }
    }
}