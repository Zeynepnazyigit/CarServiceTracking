using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceTracking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDepositRefundedColumnsToRentalAgreements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DepositRefunded",
                table: "RentalAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositRefundedDate",
                table: "RentalAgreements",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DepositRefunded", table: "RentalAgreements");
            migrationBuilder.DropColumn(name: "DepositRefundedDate", table: "RentalAgreements");
        }
    }
}
