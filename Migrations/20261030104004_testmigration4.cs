using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AynısıEvde.Migrations
{
    /// <inheritdoc />
    public partial class testmigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "kullanıcılar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "kullanıcılar");
        }
    }
}
