using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedListItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ListItems",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ListType", "ModifiedDate", "Name", "ParentId", "SortOrder" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2786), null, true, "CarType", null, "Sedan", null, 1 },
                    { 2, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2789), null, true, "CarType", null, "Hatchback", null, 2 },
                    { 3, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2791), null, true, "CarType", null, "SUV", null, 3 },
                    { 4, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2793), null, true, "CarType", null, "Station Wagon", null, 4 },
                    { 5, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2794), null, true, "CarType", null, "Pickup", null, 5 },
                    { 6, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2796), null, true, "CarType", null, "Minivan", null, 6 },
                    { 7, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2798), null, true, "CarType", null, "Coupe", null, 7 },
                    { 8, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2800), null, true, "CarType", null, "Cabrio", null, 8 },
                    { 11, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2804), null, true, "FuelType", null, "Benzin", null, 1 },
                    { 12, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2806), null, true, "FuelType", null, "Dizel", null, 2 },
                    { 13, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2807), null, true, "FuelType", null, "LPG", null, 3 },
                    { 14, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2809), null, true, "FuelType", null, "Elektrik", null, 4 },
                    { 15, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2811), null, true, "FuelType", null, "Hibrit", null, 5 },
                    { 16, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2813), null, true, "FuelType", null, "Plug-in Hibrit", null, 6 },
                    { 21, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2843), null, true, "TransmissionType", null, "Manuel", null, 1 },
                    { 22, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2845), null, true, "TransmissionType", null, "Otomatik", null, 2 },
                    { 23, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2846), null, true, "TransmissionType", null, "Yarı Otomatik", null, 3 },
                    { 24, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2848), null, true, "TransmissionType", null, "CVT", null, 4 },
                    { 25, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2850), null, true, "TransmissionType", null, "DSG", null, 5 },
                    { 31, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2854), null, true, "CustomerType", null, "Bireysel", null, 1 },
                    { 32, new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2855), null, true, "CustomerType", null, "Kurumsal", null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
