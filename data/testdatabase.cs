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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<recipe_list>().HasData(
               new recipe_list { recipe_name = "Doner", recipe_id = 1 ,recipe= "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz" }
              
           );
        }
        }
}
