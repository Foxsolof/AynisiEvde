using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AynısıEvde.model
{
    public class recipe_category_list
    {
        public int recipe_id { get; set; }

        public int category_id { get; set; }

        // Tarif listesine connector
        [ForeignKey(nameof(recipe_id))]
        public recipe_list? Recipe { get; set; }

        //malzeme listesine connector
        [ForeignKey(nameof(category_id))]
        public category_list? category { get; set; }
    }
}
