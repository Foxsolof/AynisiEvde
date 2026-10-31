using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class mainmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "malzemeler",
                columns: new[] { "ingredient_id", "ingredient_name", "ingredient_unit" },
                values: new object[,]
                {
                    { 1, "Mavi Kula", "Litre" },
                    { 2, "Meybuz", "Adet" },
                    { 3, "Hamur", "Adet" },
                    { 4, "Kıyma", "gram" }
                });

            migrationBuilder.InsertData(
                table: "recipe_List",
                columns: new[] { "recipe_id", "approval", "recipe", "recipe_name", "recipe_video", "user_id" },
                values: new object[,]
                {
                    { 2, false, "Hamura et at\r\npişir", "Lahmacun", "https://www.youtube.com/embed/_9zd7EbnBV4", null },
                    { 3, false, "Eti zırhla sonra pişir.", "Adana Kebap", "https://www.youtube.com/embed/PnRIfYSLQ2U", null }
                });

            migrationBuilder.InsertData(
                table: "recipe_Ingredient_List",
                columns: new[] { "ingredient_id", "recipe_id", "amount" },
                values: new object[,]
                {
                    { 1, 1, 10m },
                    { 2, 1, 3m },
                    { 3, 2, 3m },
                    { 4, 2, 750m },
                    { 4, 3, 750m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "recipe_Ingredient_List",
                keyColumns: new[] { "ingredient_id", "recipe_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "recipe_Ingredient_List",
                keyColumns: new[] { "ingredient_id", "recipe_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "recipe_Ingredient_List",
                keyColumns: new[] { "ingredient_id", "recipe_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "recipe_Ingredient_List",
                keyColumns: new[] { "ingredient_id", "recipe_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "recipe_Ingredient_List",
                keyColumns: new[] { "ingredient_id", "recipe_id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "malzemeler",
                keyColumn: "ingredient_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "malzemeler",
                keyColumn: "ingredient_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "malzemeler",
                keyColumn: "ingredient_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "malzemeler",
                keyColumn: "ingredient_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "recipe_List",
                keyColumn: "recipe_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "recipe_List",
                keyColumn: "recipe_id",
                keyValue: 3);
        }
    }
}
