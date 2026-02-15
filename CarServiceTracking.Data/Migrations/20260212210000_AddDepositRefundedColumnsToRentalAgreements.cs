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
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.RentalAgreements', 'DepositRefunded') IS NULL
BEGIN
    ALTER TABLE dbo.RentalAgreements ADD DepositRefunded bit NOT NULL DEFAULT 0;
END
IF COL_LENGTH('dbo.RentalAgreements', 'DepositRefundedDate') IS NULL
BEGIN
    ALTER TABLE dbo.RentalAgreements ADD DepositRefundedDate datetime2 NULL;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DepositRefunded", table: "RentalAgreements");
            migrationBuilder.DropColumn(name: "DepositRefundedDate", table: "RentalAgreements");
        }
    }
}
