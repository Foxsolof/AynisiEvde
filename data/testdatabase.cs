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
        public DbSet<recipe_ingredient_list> recipe_Ingredient_List { get; set; } = default!;
        public DbSet<recipe_category_list> recipe_category_list { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //2 primary key ayarlamak için
            base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<recipe_ingredient_list>().HasKey(tm => new { tm.recipe_id, tm.ingredient_id });
                modelBuilder.Entity<recipe_category_list>().HasKey(tm => new { tm.recipe_id, tm.category_id });
                modelBuilder.Entity<favourites_list>().HasKey(tm => new { tm.user_id, tm.recipe_id });
                modelBuilder.Entity<user_ingredient_list>().HasKey(tm => new { tm.user_id, tm.ingredient_id });
            //birimi sınırlamak için
                modelBuilder.Entity<ingredient_list>().ToTable(t => t.HasCheckConstraint("CK_ingredient_unit","ingredient_unit IN ('Litre','mililitre','Adet','gram','kilogram')"));

            // Kullanıcı ve tarif ilişkileri
            modelBuilder.Entity<recipe_list>()
                .HasOne<kullanıcı>()
                .WithMany()
                .HasForeignKey(r => r.user_id);

            modelBuilder.Entity<favourites_list>()
                .HasOne<kullanıcı>()
                .WithMany()
                .HasForeignKey(f => f.user_id);

            modelBuilder.Entity<favourites_list>()
                .HasOne<recipe_list>()
                .WithMany()
                .HasForeignKey(f => f.recipe_id);

            // Kullanıcı ve malzeme ilişkileri
            modelBuilder.Entity<user_ingredient_list>()
                .HasOne<kullanıcı>()
                .WithMany()
                .HasForeignKey(ui => ui.user_id);

            modelBuilder.Entity<user_ingredient_list>()
                .HasOne<ingredient_list>()
                .WithMany()
                .HasForeignKey(ui => ui.ingredient_id);
            //amount precision ayarı
            modelBuilder.Entity<recipe_ingredient_list>().Property(r => r.amount).HasPrecision(10, 2);
            modelBuilder.Entity<user_ingredient_list>().Property(u => u.amount).HasPrecision(10, 2);
            modelBuilder.Entity<recipe_list>().HasData(
       new recipe_list { recipe_name = "Doner", recipe_id = 1, recipe_video = "https://youtube.com/embed/438dcMfDbBw?si=d-A0darJ2C9HkCq1", recipe = "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz" },
       new recipe_list { recipe_name = "Lahmacun", recipe_id = 2, recipe_video = "https://www.youtube.com/embed/_9zd7EbnBV4", recipe = "Hamura et at\r\npişir" },
       new recipe_list { recipe_name = "Adana Kebap", recipe_id = 3, recipe_video = "https://www.youtube.com/embed/PnRIfYSLQ2U", recipe = "Eti zırhla sonra pişir." }

       );
            modelBuilder.Entity<ingredient_list>().HasData(
       new ingredient_list { ingredient_id = 1,ingredient_name="Mavi Kula",ingredient_unit="Litre" },
       new ingredient_list { ingredient_id = 2, ingredient_name = "Meybuz", ingredient_unit = "Adet" },
       new ingredient_list { ingredient_id = 3, ingredient_name = "Hamur", ingredient_unit = "Adet" },
       new ingredient_list { ingredient_id = 4, ingredient_name = "Kıyma", ingredient_unit = "gram" }

       );

            modelBuilder.Entity<recipe_ingredient_list>().HasData(
       new recipe_ingredient_list { recipe_id=1,ingredient_id = 1, amount=10},
       new recipe_ingredient_list { recipe_id = 1,ingredient_id = 2, amount = 3},
       new recipe_ingredient_list { recipe_id = 2,ingredient_id = 3, amount=3 },
       new recipe_ingredient_list { recipe_id = 2, ingredient_id = 4,amount=750},
       new recipe_ingredient_list { recipe_id = 3, ingredient_id = 4, amount = 750 }

       );
        }
        public DbSet<ingredient_list> malzemeler { get; set; } = default!;
        public DbSet<category_list> kategoriler { get; set; } = default!;
        public DbSet<favourites_list> favoriler { get; set; } = default!;
        public DbSet<user_ingredient_list> kullaniciMalzemeleri { get; set; } = default!;

    }
}
