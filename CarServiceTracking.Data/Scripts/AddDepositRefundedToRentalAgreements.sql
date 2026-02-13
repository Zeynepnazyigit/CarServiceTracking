-- RentalAgreements tablosuna depozito iade alanlarını ekler.
-- EF migration bu kolonları eklemediyse SSMS veya sqlcmd ile bu script'i çalıştırın.

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID(N'dbo.RentalAgreements') AND name = N'DepositRefunded'
)
BEGIN
    ALTER TABLE dbo.RentalAgreements
    ADD DepositRefunded bit NOT NULL DEFAULT 0;
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID(N'dbo.RentalAgreements') AND name = N'DepositRefundedDate'
)
BEGIN
    ALTER TABLE dbo.RentalAgreements
    ADD DepositRefundedDate datetime2 NULL;
END
GO
