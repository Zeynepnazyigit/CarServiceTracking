using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToRentalVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RentalVehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "Notes" },
                values: new object[] { new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(6993), "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=400&h=250&fit=crop", "Klima, ABS, Airbag, Geri Görüş Kamerası" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "Notes" },
                values: new object[] { new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7000), "https://images.unsplash.com/photo-1632245889029-e406faaa34cd?w=400&h=250&fit=crop", "Deri Koltuk, Sunroof, Navigasyon, Apple CarPlay" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "Notes" },
                values: new object[] { new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7005), "https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=400&h=250&fit=crop", "Bluetooth, Klima, Park Sensörü" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "FuelType", "ImageUrl", "Model", "Notes" },
                values: new object[] { new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7010), "Benzin", "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=400&h=250&fit=crop", "320i", "Premium Sound, Deri Döşeme, Adaptif Hız Kontrolü, M Sport Paket" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "Notes" },
                values: new object[] { new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7015), "https://images.unsplash.com/photo-1551830820-330a71b99659?w=400&h=250&fit=crop", "Park Sensörü, Klima, ABS, Ekonomik Yakıt Tüketimi" });

            migrationBuilder.InsertData(
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "Color", "CreatedDate", "DailyRate", "FuelType", "ImageUrl", "IsActive", "IsAvailable", "LastMaintenanceDate", "Mileage", "Model", "ModifiedDate", "NextMaintenanceDate", "Notes", "PlateNumber", "TransmissionType", "VehicleCondition", "Year" },
                values: new object[,]
                {
                    { 6, "Mercedes-Benz", "Beyaz", new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7022), 1800.00m, "Benzin", "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=400&h=250&fit=crop", true, true, null, 8000, "C180", null, null, "AMG Line, Burmester Ses Sistemi, Panoramik Tavan, 360° Kamera", "34 LMN 987", "Otomatik", null, 2023 },
                    { 7, "Hyundai", "Yeşil", new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7026), 1100.00m, "Hibrit", "https://images.unsplash.com/photo-1606611013016-969c19ba6c40?w=400&h=250&fit=crop", true, true, null, 3000, "Tucson", null, null, "Hibrit Motor, 4x4, Büyük Bagaj, Şerit Takip Sistemi", "07 OPQ 246", "Otomatik", null, 2024 },
                    { 8, "Audi", "Lacivert", new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7031), 1400.00m, "Dizel", "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=400&h=250&fit=crop", true, true, null, 22000, "A4", null, null, "Quattro 4x4, Virtual Cockpit, Matrix LED Far, B&O Ses Sistemi", "34 RST 135", "S-Tronic", null, 2022 },
                    { 9, "Fiat", "Gümüş", new DateTime(2026, 2, 6, 23, 40, 9, 128, DateTimeKind.Local).AddTicks(7035), 450.00m, "LPG", "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=400&h=250&fit=crop", true, true, null, 18000, "Egea", null, null, "LPG'li, Ekonomik, Geniş İç Mekan, USB Girişi", "35 UVW 864", "Manuel", null, 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RentalVehicles");

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

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Notes" },
                values: new object[] { new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7135), "Klima, ABS, Airbag" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Notes" },
                values: new object[] { new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7140), "Deri Koltuk, Sunroof, Navigasyon" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Notes" },
                values: new object[] { new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7144), "Bluetooth, Klima" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "FuelType", "Model", "Notes" },
                values: new object[] { new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7147), "Hibrit", "3 Series", "Premium Sound, Deri Döşeme, Adaptif Hız Kontrolü" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Notes" },
                values: new object[] { new DateTime(2026, 2, 2, 3, 13, 46, 736, DateTimeKind.Local).AddTicks(7150), "Park Sensörü, Klima, ABS" });
        }
    }
}
