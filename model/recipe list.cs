using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AynısıEvde.model
{
    [Index(nameof(recipe_name), IsUnique = true)]
    public class recipe_list
    {
        [Key]
        public int recipe_id { get; set; }

        [Required(ErrorMessage = "tarif adı zorunludur.")]
        [StringLength(100)]
        public string recipe_name { get; set;}

        [Required(ErrorMessage ="tarif yapılışı zorunludur.")]
        [StringLength(3000)]
        public string recipe { get; set;}

        public string recipe_video { get; set; }

        public int? user_id { get; set; } //user id

        public bool approval { get; set; } = false;
    }
}
