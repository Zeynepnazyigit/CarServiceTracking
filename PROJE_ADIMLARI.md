# CarServiceTracking – Proje Adımları (Sırayla İşleyiş)

Bu projede işler aşağıdaki sırayla ilerler. Adım adım akış burada.

---

## ADIM 1 – Giriş

1. Kullanıcı tarayıcıda uygulamayı açar.
2. **Login** sayfasına gider (`/Auth/Login`).
3. E-posta ve şifre girer.
4. Sistem hesabı kontrol eder:
   - **Admin** ise → **Adım 2 (Admin paneli)**.
   - **Müşteri** ise → **Adım 3 (Müşteri paneli)**.

---

## ADIM 2 – Admin paneli (sırayla)

1. Admin **Dashboard** açılır (özet sayılar, son talepler).
2. **Müşteriler:** Admin müşteri ekler / düzenler / listeler.
3. **Araçlar:** Müşterilere ait araçlar (plaka, marka, model) burada listelenir / yönetilir.
4. **Servis talepleri:** Müşterilerin açtığı servis talepleri listelenir; admin durum günceller (Beklemede → İşlemde → Tamamlandı), servis ücreti ve not girer.
5. **Randevular:** Randevular listelenir; admin randevu ekler / düzenler / iptal eder.
6. **Parçalar / Teknisyenler:** Envanter (parça, teknisyen) yönetilir.
7. **Faturalar:** Admin, servis talebi seçip fatura oluşturur; fatura listesi, detay, PDF indirme, düzenleme, silme (soft-delete) yapar. Aynı servis talebi için “mevcut faturayı silip yeniden oluştur” seçeneği vardır.
8. **Ödemeler:** Faturalara ödeme girilir.
9. **Kiralama:** Kiralık araçlar ve kiralama sözleşmeleri yönetilir.
10. **Çıkış:** Admin çıkış yapar; tekrar login sayfasına döner.

---

## ADIM 3 – Müşteri paneli (sırayla)

1. Müşteri giriş yaptıktan sonra **Ana sayfa** açılır (özet bilgiler).
2. **Şahsi araçlarım:** Müşteri kendi araçlarını ekler (marka, model, plaka, yıl vb.) ve listeler.
3. **Geçici araçlar:** Kiralanabilir araçları görüntüler (liste / detay).
4. **Servis kayıtlarım:** Müşteri araç seçip **servis talebi** açar (sorun açıklaması, tercih tarihi vb.).
5. **Randevularım:** Müşteri randevu oluşturur (tarih / saat); randevuları listeler.
6. **Faturalarım:** Sadece kendisine ait faturalar listelenir; detay ve PDF indirme yapılır (faturada araç bilgisi doğru gösterilir).
7. **Ödemelerim:** Müşterinin yaptığı ödemeler listelenir.
8. **Kiralamalarım:** Müşterinin kiralama sözleşmeleri listelenir; yeni kiralama (araç seçip sözleşme) varsa buradan yapılır.
9. **Çıkış:** Müşteri çıkış yapar; tekrar login sayfasına döner.

---

## ADIM 4 – Veri akışı (Admin ↔ Müşteri)

1. Müşteri **servis talebi** açar → Admin panelde “Servis Talepleri”nde görünür.
2. Admin talebi **Tamamlandı** yapar, **fiyat** girer → Bu talebe fatura kesilebilir.
3. Admin **fatura oluşturur** (Servis Talebi ID ile) → Fatura, o müşteri için “Faturalarım”da görünür; PDF’te müşteri, araç (marka/model) ve tutarlar doğrudur.
4. Müşteri **randevu** oluşturur → Admin “Randevular”da görür.
5. Admin **ödeme** kaydeder → Müşteri “Ödemelerim”de görebilir.

---

## Özet sıra

| Sıra | Kim       | Ne yapar |
|------|-----------|----------|
| 1    | Herkes    | Giriş (Login) |
| 2    | Admin     | Müşteri / Araç / Servis talebi / Randevu / Fatura / Ödeme / Kiralama yönetimi |
| 3    | Müşteri   | Araç ekleme, servis talebi açma, randevu alma, faturaları ve ödemeleri görme |
| 4    | Sistem    | Admin’de yapılanlar müşteri tarafında doğru sayfalarda görünür |

Bu dosya, yaptığın projenin **sırayla adımlarını** anlatır; rapora veya ödeve ekleyebilirsin.
