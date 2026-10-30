using Microsoft.EntityFrameworkCore;
using AynısıEvde.model;


namespace AynısıEvde.data
{
    public class testdatabase : DbContext
    {
        public testdatabase(DbContextOptions<testdatabase> options): base(options) 
        {
        }

        public DbSet<kullanıcı> kullanıcılar { get; set; } = default!;
        public DbSet<recipe_list> recipe_List { get; set; } = default!;
    }
}
