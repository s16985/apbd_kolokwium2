using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NeedSpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighters",
                columns: table => new
                {
                    IdFireFighter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighters", x => x.IdFireFighter);
                });

            migrationBuilder.CreateTable(
                name: "FireTrucks",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationalNumber = table.Column<string>(maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrucks", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter_Actions",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighter_Actions", x => new { x.IdAction, x.IdFirefighter });
                    table.ForeignKey(
                        name: "FK_Firefighter_Actions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firefighter_Actions_Firefighters_IdFirefighter",
                        column: x => x.IdFirefighter,
                        principalTable: "Firefighters",
                        principalColumn: "IdFireFighter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Actions",
                columns: table => new
                {
                    IdFireTruckAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAction = table.Column<int>(nullable: false),
                    IdFireTruck = table.Column<int>(nullable: false),
                    AssigmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTruck_Actions", x => x.IdFireTruckAction);
                    table.ForeignKey(
                        name: "FK_FireTruck_Actions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireTruck_Actions_FireTrucks_IdFireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTrucks",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_Actions_IdFirefighter",
                table: "Firefighter_Actions",
                column: "IdFirefighter");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Actions_IdAction",
                table: "FireTruck_Actions",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Actions_IdFireTruck",
                table: "FireTruck_Actions",
                column: "IdFireTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firefighter_Actions");

            migrationBuilder.DropTable(
                name: "FireTruck_Actions");

            migrationBuilder.DropTable(
                name: "Firefighters");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "FireTrucks");
        }
    }
}
