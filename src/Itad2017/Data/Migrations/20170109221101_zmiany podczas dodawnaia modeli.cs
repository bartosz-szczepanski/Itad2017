using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Itad2017.Data.Migrations
{
    public partial class zmianypodczasdodawnaiamodeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WhoID = table.Column<int>(nullable: true),
                    WorkshopID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participation_Participant_WhoID",
                        column: x => x.WhoID,
                        principalTable: "Participant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participation_Workshop_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participation_WhoID",
                table: "Participation",
                column: "WhoID");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_WorkshopID",
                table: "Participation",
                column: "WorkshopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Workshop");
        }
    }
}
