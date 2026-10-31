using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AynısıEvde.model
{
    [Index(nameof(ingredient_name), IsUnique = true)]
    public class ingredient_list
    {
        [Key]
        public int ingredient_id{ get; set; }
        [Required(ErrorMessage = "Malzeme adı zorunludur.")]
        [StringLength(100)]
        public string ingredient_name { get; set; }
        [Required(ErrorMessage = "Malzeme birimi zorunludur")]
        [StringLength(100)]
        public string ingredient_unit { get; set; }
        public ICollection<recipe_ingredient_list> TarifMalzemeleri { get; set; }
            = new List<recipe_ingredient_list>();
    }
}
