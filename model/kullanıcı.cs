using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AynısıEvde.model
{
    [Index(nameof(username), IsUnique = true)]
    public class kullanıcı
    {
        [Key]
        public int user_id { get; set; }
        
        [Required(ErrorMessage = "kullanıcı adı zorunludur.")]
        [StringLength(100)]
        public string username { get; set; }
        [Required (ErrorMessage ="şifre zorunludur.")]
        [StringLength(100)]
        public string password { get; set; }
        [Required(ErrorMessage = "mail zorunludur.")]
        public string email { get; set; }


    }
}
