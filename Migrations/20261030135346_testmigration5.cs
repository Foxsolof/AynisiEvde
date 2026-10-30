using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class testmigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                table: "kullanıcılar",
                newName: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "kullanıcılar",
                newName: "userid");
        }
    }
}
