using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class testmigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "recipe_List",
                columns: new[] { "recipe_id", "approval", "recipe", "recipe_name", "user_id" },
                values: new object[] { 1, false, "10 mavi kolayı iyice çalkalayın\nİçine azar azar meybuz eklemesi için döner ustasını kullanın\n20. Meybuzu da koyduktan sonra yeterince bilim varsa\nAfiyetle yiyebilirsiniz", "Doner", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "recipe_List",
                keyColumn: "recipe_id",
                keyValue: 1);
        }
    }
}
