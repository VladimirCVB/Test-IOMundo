using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_IOMundo.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StayDurationNights = table.Column<int>(type: "integer", nullable: false),
                    PersonCombination = table.Column<string>(type: "text", nullable: false),
                    ServiceCode = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    PricePerAdult = table.Column<int>(type: "integer", nullable: false),
                    PricePerChild = table.Column<int>(type: "integer", nullable: false),
                    StrikePrice = table.Column<int>(type: "integer", nullable: false),
                    StrikePricePerAdult = table.Column<int>(type: "integer", nullable: false),
                    StrikePricePerChild = table.Column<int>(type: "integer", nullable: false),
                    ShowStrikePrice = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
