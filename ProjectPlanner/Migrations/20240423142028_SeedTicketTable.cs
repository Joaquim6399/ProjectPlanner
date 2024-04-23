using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectPlanner.Migrations
{
    /// <inheritdoc />
    public partial class SeedTicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedOn", "Description", "Priority", "ProjectId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 15, 20, 28, 403, DateTimeKind.Local).AddTicks(2085), "Succesfully split a atom", "Medium", 1, "New", "Split Atom" },
                    { 2, new DateTime(2024, 4, 23, 15, 20, 28, 403, DateTimeKind.Local).AddTicks(2138), "Find plutunium for the bomb", "High", 1, "New", "Find Plutonium" },
                    { 3, new DateTime(2024, 4, 23, 15, 20, 28, 403, DateTimeKind.Local).AddTicks(2141), "Find someone willingly to go to the moon", "Low", 2, "New", "Find Astronaut" },
                    { 4, new DateTime(2024, 4, 23, 15, 20, 28, 403, DateTimeKind.Local).AddTicks(2144), "Create engine with w16 orientation", "Medium", 4, "New", "Create w16 engine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
