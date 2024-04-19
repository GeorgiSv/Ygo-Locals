using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YgoLocals.Migrations
{
    public partial class InitialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TournamentPlayer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TournamentPlayer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TournamentPlayer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TournamentPlayer",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TournamentPlayer");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TournamentPlayer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TournamentPlayer");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TournamentPlayer");
        }
    }
}
