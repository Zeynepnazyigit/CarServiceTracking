using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceUniqueIndexesForSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_RentalAgreementId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 17, 18, 38, 448, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RentalAgreementId",
                table: "Invoices",
                column: "RentalAgreementId",
                unique: true,
                filter: "[RentalAgreementId] IS NOT NULL AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices",
                column: "ServiceRequestId",
                unique: true,
                filter: "[ServiceRequestId] IS NOT NULL AND [IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_RentalAgreementId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "ListItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 12, 1, 47, 6, 63, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RentalAgreementId",
                table: "Invoices",
                column: "RentalAgreementId",
                unique: true,
                filter: "[RentalAgreementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices",
                column: "ServiceRequestId",
                unique: true,
                filter: "[ServiceRequestId] IS NOT NULL");
        }
    }
}
