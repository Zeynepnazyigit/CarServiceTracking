using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalAgreementToInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceRequestId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RentalAgreementId",
                table: "Invoices",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_RentalAgreements_RentalAgreementId",
                table: "Invoices",
                column: "RentalAgreementId",
                principalTable: "RentalAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_RentalAgreements_RentalAgreementId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_RentalAgreementId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RentalAgreementId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceRequestId",
                table: "Invoices",
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

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 8, 20, 55, 54, 594, DateTimeKind.Local).AddTicks(750));

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceRequestId",
                table: "Invoices",
                column: "ServiceRequestId",
                unique: true);
        }
    }
}
