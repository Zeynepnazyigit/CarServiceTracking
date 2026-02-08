using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAllVehicleImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7393), "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7402), "https://images.unsplash.com/photo-1632245889029-e406faaa34cd?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7407), "https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7412), "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7417), "https://images.unsplash.com/photo-1551830820-330a71b99659?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7423), "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7427), "https://images.unsplash.com/photo-1519681393784-d120267933ba?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7432), "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=400&h=250&fit=crop" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 7, 1, 25, 13, 947, DateTimeKind.Local).AddTicks(7437), "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=400&h=250&fit=crop" });
        }
    }
}
