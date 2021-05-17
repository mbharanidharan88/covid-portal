using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidPortal.HospitalAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    OxygenCapacityInTonnes = table.Column<float>(type: "real", nullable: false),
                    BalanceCapacityInTonnes = table.Column<float>(type: "real", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
