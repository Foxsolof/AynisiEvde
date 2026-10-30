using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class testmigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recipe_List",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recipe_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    approval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_List", x => x.recipe_id);
                    table.ForeignKey(
                        name: "FK_recipe_List_kullanıcılar_user_id",
                        column: x => x.user_id,
                        principalTable: "kullanıcılar",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_recipe_List_recipe_name",
                table: "recipe_List",
                column: "recipe_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_List_user_id",
                table: "recipe_List",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe_List");
        }
    }
}
