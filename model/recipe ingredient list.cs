using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AynısıEvde.model
{
    public class recipe_ingredient_list
    {
        public int recipe_id { get; set; }

        public int ingredient_id { get; set; }


        public decimal amount { get; set; }

        // Tarif listesine connector
        [ForeignKey(nameof(recipe_id))]
        public recipe_list? Recipe { get; set; }

        //malzeme listesine connector
        [ForeignKey(nameof(ingredient_id))]
        public ingredient_list? ingredient { get; set; }
    }
}
