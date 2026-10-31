using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class mainmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "recipe_List",
                keyColumn: "recipe_id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "recipe",
                table: "recipe_List",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "kullanıcılar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "favoriler",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    recipe_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoriler", x => new { x.user_id, x.recipe_id });
                    table.ForeignKey(
                        name: "FK_favoriler_kullanıcılar_user_id",
                        column: x => x.user_id,
                        principalTable: "kullanıcılar",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favoriler_recipe_List_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe_List",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kategoriler",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriler", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "malzemeler",
                columns: table => new
                {
                    ingredient_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredient_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ingredient_unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemeler", x => x.ingredient_id);
                    table.CheckConstraint("CK_ingredient_unit", "ingredient_unit IN ('Litre','mililitre','Adet','gram','kilogram')");
                });

            migrationBuilder.CreateTable(
                name: "recipe_category_list",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_category_list", x => new { x.recipe_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_recipe_category_list_kategoriler_category_id",
                        column: x => x.category_id,
                        principalTable: "kategoriler",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_category_list_recipe_List_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe_List",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kullaniciMalzemeleri",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ingredient_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullaniciMalzemeleri", x => new { x.user_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "FK_kullaniciMalzemeleri_kullanıcılar_user_id",
                        column: x => x.user_id,
                        principalTable: "kullanıcılar",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kullaniciMalzemeleri_malzemeler_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "malzemeler",
                        principalColumn: "ingredient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_Ingredient_List",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "int", nullable: false),
                    ingredient_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_Ingredient_List", x => new { x.recipe_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "FK_recipe_Ingredient_List_malzemeler_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "malzemeler",
                        principalColumn: "ingredient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_Ingredient_List_recipe_List_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipe_List",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kullanıcılar_email",
                table: "kullanıcılar",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_favoriler_recipe_id",
                table: "favoriler",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_kategoriler_category_name",
                table: "kategoriler",
                column: "category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_kullaniciMalzemeleri_ingredient_id",
                table: "kullaniciMalzemeleri",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_malzemeler_ingredient_name",
                table: "malzemeler",
                column: "ingredient_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_category_list_category_id",
                table: "recipe_category_list",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_Ingredient_List_ingredient_id",
                table: "recipe_Ingredient_List",
                column: "ingredient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoriler");

            migrationBuilder.DropTable(
                name: "kullaniciMalzemeleri");

            migrationBuilder.DropTable(
                name: "recipe_category_list");

            migrationBuilder.DropTable(
                name: "recipe_Ingredient_List");

            migrationBuilder.DropTable(
                name: "kategoriler");

            migrationBuilder.DropTable(
                name: "malzemeler");

            migrationBuilder.DropIndex(
                name: "IX_kullanıcılar_email",
                table: "kullanıcılar");

            migrationBuilder.AlterColumn<string>(
                name: "recipe",
                table: "recipe_List",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "kullanıcılar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "recipe_List",
                columns: new[] { "recipe_id", "approval", "recipe", "recipe_name", "user_id" },
                values: new object[] { 1, false, "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz", "Doner", null });
        }
    }
}
