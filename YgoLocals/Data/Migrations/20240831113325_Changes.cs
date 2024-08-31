using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YgoLocals.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_AspNetUsers_UserId",
                table: "Deck");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerOneDeckId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerTwoeDeckId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_OrganizerId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_TournamentPlayer_IdlePlayerId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayer_AspNetUsers_PlayerId",
                table: "TournamentPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayerDeck_Deck_DeckId",
                table: "TournamentPlayerDeck");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayerDeck_TournamentPlayer_TournamentPlayerId",
                table: "TournamentPlayerDeck");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "TournamentPlayer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdlePlayerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerTwoeDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerTwoDeckId",
                table: "Match",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerOneDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Deck",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_AspNetUsers_UserId",
                table: "Deck",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Deck_PlayerOneDeckId",
                table: "Match",
                column: "PlayerOneDeckId",
                principalTable: "Deck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Deck_PlayerTwoeDeckId",
                table: "Match",
                column: "PlayerTwoeDeckId",
                principalTable: "Deck",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_OrganizerId",
                table: "Tournament",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_TournamentPlayer_IdlePlayerId",
                table: "Tournament",
                column: "IdlePlayerId",
                principalTable: "TournamentPlayer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayer_AspNetUsers_PlayerId",
                table: "TournamentPlayer",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayerDeck_Deck_DeckId",
                table: "TournamentPlayerDeck",
                column: "DeckId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayerDeck_TournamentPlayer_TournamentPlayerId",
                table: "TournamentPlayerDeck",
                column: "TournamentPlayerId",
                principalTable: "TournamentPlayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_AspNetUsers_UserId",
                table: "Deck");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerOneDeckId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Deck_PlayerTwoeDeckId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_OrganizerId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_TournamentPlayer_IdlePlayerId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayer_AspNetUsers_PlayerId",
                table: "TournamentPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayerDeck_Deck_DeckId",
                table: "TournamentPlayerDeck");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayerDeck_TournamentPlayer_TournamentPlayerId",
                table: "TournamentPlayerDeck");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "TournamentPlayer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdlePlayerId",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerTwoeDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerTwoDeckId",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerOneDeckId",
                table: "Match",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Deck",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_AspNetUsers_UserId",
                table: "Deck",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_OrganizerId",
                table: "Tournament",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_TournamentPlayer_IdlePlayerId",
                table: "Tournament",
                column: "IdlePlayerId",
                principalTable: "TournamentPlayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayer_AspNetUsers_PlayerId",
                table: "TournamentPlayer",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayerDeck_Deck_DeckId",
                table: "TournamentPlayerDeck",
                column: "DeckId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentPlayerDeck_TournamentPlayer_TournamentPlayerId",
                table: "TournamentPlayerDeck",
                column: "TournamentPlayerId",
                principalTable: "TournamentPlayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
