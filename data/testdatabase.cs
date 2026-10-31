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
       new recipe_list { recipe_name = "Doner", recipe_id = 1, recipe_video = "https://youtube.com/embed/438dcMfDbBw?si=d-A0darJ2C9HkCq1", recipe = "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz" });
        }
        public DbSet<ingredient_list> malzemeler { get; set; } = default!;
        public DbSet<category_list> kategoriler { get; set; } = default!;
        public DbSet<favourites_list> favoriler { get; set; } = default!;
        public DbSet<user_ingredient_list> kullaniciMalzemeleri { get; set; } = default!;

    }
}
