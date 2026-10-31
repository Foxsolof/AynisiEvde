using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class testmigration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "recipe_video",
                table: "recipe_List",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recipe_video",
                table: "recipe_List");
        }
    }
}
