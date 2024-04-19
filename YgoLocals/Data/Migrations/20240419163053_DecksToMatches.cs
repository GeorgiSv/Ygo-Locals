using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YgoLocals.Migrations
{
    public partial class DecksToMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerOneDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerTwoDeckId",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerTwoeDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerOneDeckId",
                table: "Match",
                column: "PlayerOneDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerTwoeDeckId",
                table: "Match",
                column: "PlayerTwoeDeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Deck_PlayerOneDeckId",
                table: "Match",
                column: "PlayerOneDeckId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Deck_PlayerTwoeDeckId",
                table: "Match",
                column: "PlayerTwoeDeckId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerOneDeckId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerTwoeDeckId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_PlayerOneDeckId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_PlayerTwoeDeckId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "PlayerOneDeckId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "PlayerTwoDeckId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "PlayerTwoeDeckId",
                table: "Match");
        }
    }
}
