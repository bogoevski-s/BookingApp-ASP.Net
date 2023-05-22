using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedQuantity = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "Developers", 5 },
                    { 2, "QA", 3 },
                    { 3, "HR", 4 },
                    { 4, "DevOps", 7 },
                    { 5, "Designer", 9 },
                    { 6, "Managers", 4 },
                    { 7, "Recruiters", 1 },
                    { 8, "System Administrator", 1 },
                    { 9, "Account Executive", 8 },
                    { 10, "Sales", 11 },
                    { 11, "Marketing", 6 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[] { 1, 2, new DateTime(2023, 5, 22, 19, 19, 8, 912, DateTimeKind.Utc).AddTicks(9399), new DateTime(2023, 5, 23, 19, 19, 8, 912, DateTimeKind.Utc).AddTicks(9403), 1 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[] { 2, 1, new DateTime(2023, 5, 21, 19, 19, 8, 912, DateTimeKind.Utc).AddTicks(9404), new DateTime(2023, 5, 22, 19, 19, 8, 912, DateTimeKind.Utc).AddTicks(9404), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
