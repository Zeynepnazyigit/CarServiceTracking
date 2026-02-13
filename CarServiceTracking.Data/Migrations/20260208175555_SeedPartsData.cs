using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPartsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "IsActive", "MinStockLevel", "ModifiedDate", "PartCode", "PartName", "StockQuantity", "Supplier", "SupplierContact", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Motor", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(712), "Universal yağ filtresi, çoğu benzinli araçla uyumlu", true, 10, null, "MF-001", "Yağ Filtresi", 50, "Bosch Türkiye", "0212 555 10 10", 150.00m },
                    { 2, "Motor", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(717), "Motor hava filtresi, 1.4-1.6 motor hacmi", true, 8, null, "MF-002", "Hava Filtresi", 40, "Mann Filter", "0216 444 20 20", 120.00m },
                    { 3, "Motor", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(720), "İridyum buji seti, 4 silindirli motorlar için", true, 5, null, "MF-003", "Buji Seti (4 Adet)", 25, "NGK", "0212 333 40 40", 480.00m },
                    { 4, "Motor", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(722), "Triger kayışı + gergi rulmanı seti", true, 3, null, "MF-004", "Triger Kayışı Seti", 12, "Gates", "0216 555 30 30", 1250.00m },
                    { 5, "Fren", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(725), "Ön aks fren balata takımı, seramik", true, 6, null, "FR-001", "Ön Fren Balata Seti", 30, "Ferodo", "0212 444 50 50", 350.00m },
                    { 6, "Fren", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(727), "Arka aks fren balata takımı", true, 6, null, "FR-002", "Arka Fren Balata Seti", 28, "Ferodo", "0212 444 50 50", 280.00m },
                    { 7, "Fren", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(730), "Ön aks fren disk takımı, havalandırmalı", true, 4, null, "FR-003", "Fren Diski (Ön - Çift)", 15, "Brembo", "0216 666 70 70", 900.00m },
                    { 8, "Süspansiyon", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(732), "Ön aks gaz amortisör takımı", true, 3, null, "SS-001", "Ön Amortisör (Çift)", 8, "Monroe", "0212 777 80 80", 1800.00m },
                    { 9, "Süspansiyon", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(734), "Ön aks rotil takımı", true, 5, null, "SS-002", "Rotil (Çift)", 20, "TRW", "0216 888 90 90", 450.00m },
                    { 10, "Elektrik", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(737), "12V 60Ah başlatma aküsü", true, 3, null, "EL-001", "Akü 60Ah", 10, "Mutlu Akü", "0212 999 10 10", 2200.00m },
                    { 11, "Elektrik", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(739), "H7 halojen far ampulü seti", true, 10, null, "EL-002", "Far Ampulü H7 (Çift)", 35, "Philips", "0216 111 20 20", 180.00m },
                    { 12, "Sarf Malzeme", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(742), "Tam sentetik motor yağı 5W-30, 4 litre", true, 15, null, "SM-001", "Motor Yağı 5W-30 (4L)", 60, "Castrol", "0212 222 30 30", 750.00m },
                    { 13, "Sarf Malzeme", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(744), "Uzun ömürlü antifriz, -40°C koruma", true, 8, null, "SM-002", "Antifriz (3L)", 25, "Motul", "0216 333 40 40", 220.00m },
                    { 14, "Sarf Malzeme", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(746), "DOT4 fren hidrolik yağı", true, 10, null, "SM-003", "Fren Hidroliği DOT4 (500ml)", 40, "Bosch Türkiye", "0212 555 10 10", 95.00m },
                    { 15, "Klima", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(748), "Universal klima kompresörü", true, 3, null, "KL-001", "Klima Kompresörü", 2, "Denso", "0212 444 60 60", 4500.00m },
                    { 16, "Motor", new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(750), "1.5 dCi turbo şarj ünitesi", true, 2, null, "MF-005", "Turbo Şarj", 1, "Garrett", "0216 555 70 70", 8500.00m }
                });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(675));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8447));
        }
    }
}
