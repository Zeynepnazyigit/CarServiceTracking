using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixVehicleImagesWithRealUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8404), "https://www.arabazzi.com/images/yuklemeler/corolla-14079.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8411), "https://www.arabazzi.com/images/model_gorsel/passat223.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8416), "https://www.arabazzi.com/images/yuklemeler/renault-megane-sedan2340.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8421), "https://www.arabazzi.com/images/model_gorsel/3-serisi22.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8426), "https://www.arabazzi.com/images/model_gorsel/focus-2019244.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8432), "https://www.arabazzi.com/images/model_gorsel/c-serisi123.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8437), "https://www.arabazzi.com/images/yuklemeler/hyundai-tucson-nasil8975.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8442), "https://www.arabazzi.com/images/model_gorsel/a48.jpg" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 16, 55, 54, 79, DateTimeKind.Local).AddTicks(8447), "https://www.arabazzi.com/images/model_gorsel/egea-sedan62.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(776), "https://images.unsplash.com/photo-1621007947382-bb3c3994e3fb?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(786), "https://images.unsplash.com/photo-1622353212916-6eb0e86b20be?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(792), "https://images.unsplash.com/photo-1605559424843-9e4c228bf1c2?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(799), "https://images.unsplash.com/photo-1617531653520-bd466c2d0ea9?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(805), "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(813), "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(869), "https://images.unsplash.com/photo-1611859266238-4b98091d9d9b?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(875), "https://images.unsplash.com/photo-1610768764270-790fbec18178?w=800&h=500&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 44, 21, 115, DateTimeKind.Local).AddTicks(881), "https://images.unsplash.com/photo-1583121274602-3e2820c69888?w=800&h=500&fit=crop" });
        }
    }
}
