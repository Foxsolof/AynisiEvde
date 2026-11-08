namespace AynısıEvde.model
{
    public class RecipeRequest
    {
        public string recipe_name { get; set; } = "";
        public string recipe { get; set; } = "";
        public string recipe_video { get; set; } = "";
        public List<IngredientRequest> ingredients { get; set; } = new();
    }

    public class IngredientRequest
    {
        public string name { get; set; } = "";
        public decimal amount { get; set; }
        public string unit { get; set; } = "";
    }
}