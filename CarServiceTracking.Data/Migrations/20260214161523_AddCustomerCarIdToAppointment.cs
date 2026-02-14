using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerCarIdToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerCarId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 14, 19, 15, 22, 709, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerCarId",
                table: "Appointments",
                column: "CustomerCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CustomerCars_CustomerCarId",
                table: "Appointments",
                column: "CustomerCarId",
                principalTable: "CustomerCars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CustomerCars_CustomerCarId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerCarId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CustomerCarId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 23, 21, 22, 364, DateTimeKind.Local).AddTicks(4799));
        }
    }
}
