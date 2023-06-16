using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocypt.Migrations
{
    /// <inheritdoc />
    public partial class correcaoExcluir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_Grupo_GrupoId",
                table: "Password");

            migrationBuilder.AlterColumn<Guid>(
                name: "GrupoId",
                table: "Password",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Password_Grupo_GrupoId",
                table: "Password",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_Grupo_GrupoId",
                table: "Password");

            migrationBuilder.AlterColumn<Guid>(
                name: "GrupoId",
                table: "Password",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_Grupo_GrupoId",
                table: "Password",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id");
        }
    }
}
