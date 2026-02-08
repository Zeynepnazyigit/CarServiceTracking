using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalVehiclesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.InsertData(
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "Color", "CreatedDate", "DailyRate", "FuelType", "IsActive", "IsAvailable", "LastMaintenanceDate", "Mileage", "Model", "ModifiedDate", "NextMaintenanceDate", "Notes", "PlateNumber", "TransmissionType", "VehicleCondition", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "Beyaz", new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7135), 750.00m, "Benzin", true, true, null, 15000, "Corolla", null, null, "Klima, ABS, Airbag", "34 ABC 123", "Otomatik", null, 2023 },
                    { 2, "Volkswagen", "Siyah", new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7140), 900.00m, "Dizel", true, true, null, 28000, "Passat", null, null, "Deri Koltuk, Sunroof, Navigasyon", "06 XYZ 456", "DSG", null, 2022 },
                    { 3, "Renault", "Kırmızı", new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7144), 650.00m, "Benzin", true, true, null, 5000, "Megane", null, null, "Bluetooth, Klima", "35 DEF 789", "Manuel", null, 2024 }
                });

            migrationBuilder.InsertData(
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "Color", "CreatedDate", "DailyRate", "FuelType", "IsActive", "LastMaintenanceDate", "Mileage", "Model", "ModifiedDate", "NextMaintenanceDate", "Notes", "PlateNumber", "TransmissionType", "VehicleCondition", "Year" },
                values: new object[] { 4, "BMW", "Gri", new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7147), 1500.00m, "Hibrit", true, null, 12000, "3 Series", null, null, "Premium Sound, Deri Döşeme, Adaptif Hız Kontrolü", "16 GHI 321", "Otomatik", null, 2023 });

            migrationBuilder.InsertData(
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "Color", "CreatedDate", "DailyRate", "FuelType", "IsActive", "IsAvailable", "LastMaintenanceDate", "Mileage", "Model", "ModifiedDate", "NextMaintenanceDate", "Notes", "PlateNumber", "TransmissionType", "VehicleCondition", "Year" },
                values: new object[] { 5, "Ford", "Mavi", new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7150), 550.00m, "Dizel", true, true, null, 45000, "Focus", null, null, "Park Sensörü, Klima, ABS", "41 JKL 654", "Manuel", null, 2021 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 0, 24, 0, 198, DateTimeKind.Local).AddTicks(2855));
        }
    }
}
