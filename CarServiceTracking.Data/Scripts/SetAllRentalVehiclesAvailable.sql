-- ============================================================
-- Tüm kiralık araçları müsait (IsAvailable = 1) yapar.
-- Katmanlı mimari dışında, doğrudan veritabanında çalıştırmak için.
-- Kullanım: SSMS veya sqlcmd ile bu dosyayı çalıştırın.
-- ============================================================

BEGIN TRANSACTION;

-- Silinmemiş kayıtları güncelle (Query Filter ile uyumlu)
UPDATE dbo.RentalVehicles
SET IsAvailable = 1,
    ModifiedDate = GETUTCDATE()
WHERE IsDeleted = 0;

-- Etkilenen satır sayısı (kontrol için)
SELECT @@ROWCOUNT AS GuncellenenAracSayisi;

COMMIT TRANSACTION;
