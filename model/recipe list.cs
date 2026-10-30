using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AynısıEvde.model
{
    [Index(nameof(recipe_name), IsUnique = true)]
    public class recipe_list
    {
        [Required(ErrorMessage = "tarif adı zorunludur.")]
        [StringLength(100)]
        public string recipe_name { get; set;}
        [Key]
        public int recipe_id { get; set; }

        [Required(ErrorMessage ="tarif yapılışı zorunludur.")]
        public string recipe { get; set;}

        public int? user_id { get; set; } //user id
        [ForeignKey(nameof(user_id))]
        public kullanıcı? User { get; set; }

        public bool approval { get; set; } = false;
    }
}
