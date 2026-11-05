using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favoriler_kullanıcılar_user_id",
                table: "favoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_favoriler_recipe_List_recipe_id",
                table: "favoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_kullaniciMalzemeleri_kullanıcılar_user_id",
                table: "kullaniciMalzemeleri");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_category_list_recipe_List_recipe_id",
                table: "recipe_category_list");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_Ingredient_List_recipe_List_recipe_id",
                table: "recipe_Ingredient_List");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_List_kullanıcılar_user_id",
                table: "recipe_List");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipe_List",
                table: "recipe_List");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kullanıcılar",
                table: "kullanıcılar");

            migrationBuilder.RenameTable(
                name: "recipe_List",
                newName: "recipes_table");

            migrationBuilder.RenameTable(
                name: "kullanıcılar",
                newName: "user_data_table");

            migrationBuilder.RenameIndex(
                name: "IX_recipe_List_user_id",
                table: "recipes_table",
                newName: "IX_recipes_table_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_recipe_List_recipe_name",
                table: "recipes_table",
                newName: "IX_recipes_table_recipe_name");

            migrationBuilder.RenameIndex(
                name: "IX_kullanıcılar_username",
                table: "user_data_table",
                newName: "IX_user_data_table_username");

            migrationBuilder.RenameIndex(
                name: "IX_kullanıcılar_email",
                table: "user_data_table",
                newName: "IX_user_data_table_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipes_table",
                table: "recipes_table",
                column: "recipe_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_data_table",
                table: "user_data_table",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_favoriler_recipes_table_recipe_id",
                table: "favoriler",
                column: "recipe_id",
                principalTable: "recipes_table",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favoriler_user_data_table_user_id",
                table: "favoriler",
                column: "user_id",
                principalTable: "user_data_table",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kullaniciMalzemeleri_user_data_table_user_id",
                table: "kullaniciMalzemeleri",
                column: "user_id",
                principalTable: "user_data_table",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_category_list_recipes_table_recipe_id",
                table: "recipe_category_list",
                column: "recipe_id",
                principalTable: "recipes_table",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_Ingredient_List_recipes_table_recipe_id",
                table: "recipe_Ingredient_List",
                column: "recipe_id",
                principalTable: "recipes_table",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_table_user_data_table_user_id",
                table: "recipes_table",
                column: "user_id",
                principalTable: "user_data_table",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favoriler_recipes_table_recipe_id",
                table: "favoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_favoriler_user_data_table_user_id",
                table: "favoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_kullaniciMalzemeleri_user_data_table_user_id",
                table: "kullaniciMalzemeleri");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_category_list_recipes_table_recipe_id",
                table: "recipe_category_list");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_Ingredient_List_recipes_table_recipe_id",
                table: "recipe_Ingredient_List");

            migrationBuilder.DropForeignKey(
                name: "FK_recipes_table_user_data_table_user_id",
                table: "recipes_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_data_table",
                table: "user_data_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipes_table",
                table: "recipes_table");

            migrationBuilder.RenameTable(
                name: "user_data_table",
                newName: "kullanıcılar");

            migrationBuilder.RenameTable(
                name: "recipes_table",
                newName: "recipe_List");

            migrationBuilder.RenameIndex(
                name: "IX_user_data_table_username",
                table: "kullanıcılar",
                newName: "IX_kullanıcılar_username");

            migrationBuilder.RenameIndex(
                name: "IX_user_data_table_email",
                table: "kullanıcılar",
                newName: "IX_kullanıcılar_email");

            migrationBuilder.RenameIndex(
                name: "IX_recipes_table_user_id",
                table: "recipe_List",
                newName: "IX_recipe_List_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_recipes_table_recipe_name",
                table: "recipe_List",
                newName: "IX_recipe_List_recipe_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kullanıcılar",
                table: "kullanıcılar",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipe_List",
                table: "recipe_List",
                column: "recipe_id");

            migrationBuilder.AddForeignKey(
                name: "FK_favoriler_kullanıcılar_user_id",
                table: "favoriler",
                column: "user_id",
                principalTable: "kullanıcılar",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favoriler_recipe_List_recipe_id",
                table: "favoriler",
                column: "recipe_id",
                principalTable: "recipe_List",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kullaniciMalzemeleri_kullanıcılar_user_id",
                table: "kullaniciMalzemeleri",
                column: "user_id",
                principalTable: "kullanıcılar",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_category_list_recipe_List_recipe_id",
                table: "recipe_category_list",
                column: "recipe_id",
                principalTable: "recipe_List",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_Ingredient_List_recipe_List_recipe_id",
                table: "recipe_Ingredient_List",
                column: "recipe_id",
                principalTable: "recipe_List",
                principalColumn: "recipe_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_List_kullanıcılar_user_id",
                table: "recipe_List",
                column: "user_id",
                principalTable: "kullanıcılar",
                principalColumn: "user_id");
        }
    }
}
