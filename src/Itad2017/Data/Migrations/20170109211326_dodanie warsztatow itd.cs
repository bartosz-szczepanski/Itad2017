using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Itad2017.Data.Migrations
{
    public partial class dodaniewarsztatowitd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Participant");

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    TshirtSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "DetailsID",
                table: "Participant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participant_DetailsID",
                table: "Participant",
                column: "DetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Detail_DetailsID",
                table: "Participant",
                column: "DetailsID",
                principalTable: "Detail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Detail_DetailsID",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_DetailsID",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "DetailsID",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Participant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
