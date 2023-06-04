using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocypt.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindogrupoPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Password",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Password",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Password",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Password");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Password");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Password");
        }
    }
}
