using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AynısıEvde.Pages
{
    public class IndexModel : BaseButtonedPageModel
    {
        public string username { get; set; } = "";
        public List<string> videotitles { get; set; } = new();
        public void OnGet()
        {
            videotitles = new List<string>  
            {
                "günün çorbası",
                "günün ana yemeği",
                "günün aperatifi",
                "günün tatlısı"
            };
            username = "misafir";   //sonradan veritabanını kontrol ederek eğer kullanıcı girişi yapılmış ise kullanıcı adını gösterilecek


        }
    }
}
