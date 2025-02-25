﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddResto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restorans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageCheck = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    NumberOfTables = table.Column<int>(type: "int", nullable: false),
                    Сuisine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WiFi = table.Column<bool>(type: "bit", nullable: false),
                    DanceFloor = table.Column<bool>(type: "bit", nullable: false),
                    Karaoke = table.Column<bool>(type: "bit", nullable: false),
                    Parking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restorans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminResto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenId = table.Column<long>(type: "bigint", nullable: false),
                    RestoranId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminResto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminResto_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminResto_Restorans_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Restorans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BronResto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BronRespNumber = table.Column<int>(type: "int", nullable: false),
                    NumberOfTables = table.Column<int>(type: "int", nullable: false),
                    PhUserNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfVisitors = table.Column<int>(type: "int", nullable: false),
                    DateOfVisitors = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateReservation = table.Column<bool>(type: "bit", nullable: false),
                    RestoransesId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronResto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BronResto_Restorans_RestoransesId",
                        column: x => x.RestoransesId,
                        principalTable: "Restorans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminResto_CitizenId",
                table: "AdminResto",
                column: "CitizenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminResto_RestoranId",
                table: "AdminResto",
                column: "RestoranId");

            migrationBuilder.CreateIndex(
                name: "IX_BronResto_RestoransesId",
                table: "BronResto",
                column: "RestoransesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminResto");

            migrationBuilder.DropTable(
                name: "BronResto");

            migrationBuilder.DropTable(
                name: "Restorans");
        }
    }
}
