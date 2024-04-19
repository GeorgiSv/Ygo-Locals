using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YgoLocals.Migrations
{
    public partial class SetWinnerAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_AspNetUsers_WinnerId",
                table: "Match");

            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_AspNetUsers_WinnerId",
                table: "Match",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_AspNetUsers_WinnerId",
                table: "Match");

            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_AspNetUsers_WinnerId",
                table: "Match",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
