using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AynısıEvde.model
{
    [Index(nameof(category_name), IsUnique = true)]
    public class category_list
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        [StringLength(100)]
        public string category_name { get; set; }
    }
}
