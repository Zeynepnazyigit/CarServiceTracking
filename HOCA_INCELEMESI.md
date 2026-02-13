# CarServiceTracking – Hoca İncelemesi (Teslim Öncesi)

Bu belge, projeyi teslim etmeden önce incelemeniz için kısa bir rehberdir.

---

## 1. Projeyi Çalıştırma (5 adım)

1. **SQL Server** çalışır olsun (LocalDB / Express / tam sürüm).
2. **Veritabanını oluşturun:**  
   `CarServiceTracking.API` klasöründe:
   ```bash
   dotnet ef database update
   ```
3. **API’yi başlatın:**  
   `CarServiceTracking.API` → `dotnet run`  
   (Port: **5130**)
4. **Web’i başlatın:**  
   `CarServiceTracking.UI.Web` → `dotnet run`  
   (Port: **5070**)
5. Tarayıcıda **http://localhost:5070** açın → **Giriş** sayfasından Admin veya Müşteri ile giriş yapın.

*Bağlantı hatası alırsanız:* `CarServiceTracking.API/appsettings.json` içinde `ConnectionStrings:DefaultConnection` değerini kendi SQL Server adınıza göre düzenleyin (örn. `.\SQLEXPRESS` veya `(localdb)\MSSQLLocalDB`).

---

## 2. İncelemede Bakılabilecekler

- **Mimari:** Çözümde Core, Data, Business, API, UI.Web katmanları ayrı projeler halinde.
- **Admin paneli:** Dashboard, Araçlar, Müşteriler, Servis Talepleri, Randevular, Parçalar, Teknisyenler, Faturalar, Ödemeler, Kiralık Araçlar, Kiralama Sözleşmeleri.
- **Müşteri paneli:** Ana sayfa, Şahsi Araçlarım, Geçici Araçlar (kiralanabilir), Servis Talepleri, Randevular, Faturalarım, Ödemelerim, Kiralamalarım.
- **Kiralama:** Araç kiralama akışı, sözleşme oluşturma, depozito iade bilgisi, fatura/ödeme entegrasyonu.

---

## 3. Detaylı Test Listesi

Tüm ekranlar ve senaryolar için madde madde kontrol listesi:  
**[TEST_KONTROL_LISTESI.md](TEST_KONTROL_LISTESI.md)**

---

## 4. Giriş Bilgileri (Hoca İçin)

Proje seed verisi ile geliyorsa aşağıdaki hesaplar kullanılabilir. Farklı kullanıyorsanız bu bölümü kendi bilgilerinizle güncelleyip hocaya iletebilirsiniz.

| Rol     | E-posta              | Şifre       |
|---------|----------------------|-------------|
| **Admin**   | admin@demo.com        | 12345678!   |
| **Müşteri** | user1@demo.com        | 12345678!   |
| **Müşteri** | user2@demo.com        | 12345678!   |
| **Müşteri** | user3@demo.com        | 12345678!   |

*Giriş sayfası: http://localhost:5070/Auth/Login*

---

## 5. Özet

- **Proje:** CarServiceTracking – Araç servis takip + kiralama  
- **Giriş:** http://localhost:5070/Auth/Login  
- **Admin:** http://localhost:5070/AdminDashboard/Index  
- **Müşteri:** http://localhost:5070/Customer/Home/Index  

İnceleme sırasında sorunuz olursa öğrenci ile iletişime geçebilirsiniz.
