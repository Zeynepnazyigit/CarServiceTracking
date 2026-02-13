# CarServiceTracking – Test Kontrol Listesi

Projeyi test ederken aşağıdaki maddeleri sırayla kontrol edebilirsiniz.

---

## GİRİŞ (Auth)

- [ ] **Login:** `/Auth/Login` – E-posta/şifre ile giriş (Admin veya Müşteri hesabı).
- [ ] **Logout:** Sağ üst Çıkış ile çıkış; tekrar login sayfasına düşme.
- [ ] **Yanlış şifre:** Hata mesajı görünmeli.
- [ ] **Admin girişi:** Giriş sonrası Admin panel (Dashboard) açılmalı.
- [ ] **Müşteri girişi:** Giriş sonrası Müşteri ana sayfası açılmalı.

---

## ADMIN PANELİ

### Dashboard (AdminDashboard)
- [ ] **Index:** `/AdminDashboard/Index` – Özet KPI'lar (toplam araç, müşteri, servis talebi vb.) görünüyor mu?
- [ ] **Son servis talepleri / randevular** listeleniyor mu?

### Yönetim – Araçlar (AdminCars)
- [ ] **Liste:** `/AdminCars/Index` – Tüm araçlar listeleniyor mu?
- [ ] **Detay:** Bir araca tıklayınca plaka, marka/model, müşteri bilgisi görünüyor mu?
- [ ] **Oluştur / Düzenle / Sil** (varsa) çalışıyor mu?

### Yönetim – Müşteriler (AdminCustomers)
- [ ] **Liste:** `/AdminCustomers/Index` – Müşteri listesi geliyor mu?
- [ ] **Detay:** Müşteri adı, telefon, araç sayısı vb. doğru mu?
- [ ] **Yeni müşteri** ekleme (varsa) çalışıyor mu?
- [ ] **Düzenle / Pasif et** (varsa) çalışıyor mu?

### Yönetim – Servis Talepleri (AdminServiceRequests)
- [ ] **Liste:** `/AdminServiceRequests/Index` – Tüm servis talepleri listeleniyor mu?
- [ ] **Detay:** Talep detayı, araç (marka/model), müşteri, durum görünüyor mu?
- [ ] **Durum güncelleme:** Beklemede → İşlemde / Tamamlandı geçişi çalışıyor mu?
- [ ] **Fiyat / not girişi:** Servis ücreti ve admin notu kaydediliyor mu?

### Yönetim – Randevular (AdminAppointments)
- [ ] **Liste:** `/AdminAppointments/Index` – Randevular tarih/saat ile listeleniyor mu?
- [ ] **Oluştur / Düzenle / İptal** (varsa) çalışıyor mu?

### Envanter – Parçalar (AdminParts)
- [ ] **Liste:** `/AdminParts/Index` – Parça listesi görünüyor mu?
- [ ] **Ekle / Düzenle / Sil** (varsa) çalışıyor mu?

### Envanter – Teknisyenler (AdminMechanics)
- [ ] **Liste:** `/AdminMechanics/Index` – Teknisyen listesi görünüyor mu?
- [ ] **Ekle / Düzenle** (varsa) çalışıyor mu?

### Finans – Faturalar (AdminInvoices)
- [ ] **Liste:** `/AdminInvoices/Index` – Faturalar listeleniyor mu? (durum filtresi varsa test et.)
- [ ] **Vadesi geçenler:** `/AdminInvoices/Overdue` – Vadesi geçmiş faturalar listeleniyor mu?
- [ ] **Detay:** Fatura detayı (müşteri, araç, tutarlar, ödeme durumu) doğru mu?
- [ ] **Yeni fatura:** `/AdminInvoices/Create` – Servis Talebi ID girip "Fatura Oluştur" ile fatura oluşuyor mu?
- [ ] **Çakışma durumu:** Aynı servis talebi için zaten fatura varsa uyarı mesajı çıkıyor mu?
- [ ] **Mevcut faturayı silip yeniden oluştur:** Checkbox işaretleyip aynı servis talebi için yeni fatura oluşuyor mu? (Fatura numarası çakışması olmamalı.)
- [ ] **PDF indir:** Fatura detaydan PDF indirme; açıldığında müşteri, **araç (doğru marka/model)**, tutarlar doğru mu?
- [ ] **Düzenle:** Not vb. alanlar güncelleniyor mu?
- [ ] **Sil:** Fatura soft-delete ile "siliniyor" mu?

### Finans – Ödemeler (AdminPayments)
- [ ] **Liste:** `/AdminPayments/Index` – Ödemeler listeleniyor mu?
- [ ] **Ödeme ekleme** (faturaya ödeme girme) çalışıyor mu?

### Kiralama – Kiralık Araçlar (AdminRentalVehicles)
- [ ] **Liste:** `/AdminRentalVehicles/Index` – Kiralanabilir araçlar listeleniyor mu?
- [ ] **Ekle / Düzenle** (varsa) çalışıyor mu?

### Kiralama – Kiralama Sözleşmeleri (AdminRentalAgreements)
- [ ] **Liste:** `/AdminRentalAgreements/Index` – Sözleşmeler listeleniyor mu?
- [ ] **Detay / Vadesi geçenler** (varsa) çalışıyor mu?

### Listeler / Ayarlar (AdminListItems, AdminSettings)
- [ ] **AdminListItems:** Liste tipleri (yakıt, vites vb.) görünüyor mu?
- [ ] **AdminSettings:** Varsa ayar sayfaları çalışıyor mu?

---

## MÜŞTERİ PANELİ

### Ana Sayfa (CustomerHome)
- [ ] **Index:** `/Customer/Home/Index` – Özet bilgiler (araç sayısı, bekleyen faturalar vb.) görünüyor mu?
- [ ] **Kısa listeler** (son servis talepleri, randevular vb.) doğru mu?

### Araç & Servis – Şahsi Araçlarım (CustomerCars)
- [ ] **Liste:** `/Customer/Cars/Index` – Müşterinin kendi araçları listeleniyor mu?
- [ ] **Yeni araç ekle:** Marka, model, plaka, yıl vb. kaydediliyor mu?
- [ ] **Araç detay:** Detay sayfası doğru bilgileri gösteriyor mu?

### Araç & Servis – Geçici Araçlar (CustomerCarsList)
- [ ] **Liste:** `/Customer/CarsList/Index` – Kiralanabilir (geçici) araçlar listeleniyor mu?
- [ ] **Detay:** Araç detay sayfası açılıyor mu?

### Araç & Servis – Servis Kayıtlarım (CustomerServiceRequests)
- [ ] **Liste:** `/Customer/ServiceRequests/Index` – Müşterinin servis talepleri listeleniyor mu?
- [ ] **Yeni talep:** Araç seçip açıklama/tarih ile talep oluşturuluyor mu?
- [ ] **Detay:** Talep durumu ve bilgileri doğru mu?
- [ ] **Düzenle** (varsa) çalışıyor mu?

### Araç & Servis – Randevularım (CustomerAppointments)
- [ ] **Liste:** `/Customer/Appointments/Index` – Müşterinin randevuları listeleniyor mu?
- [ ] **Yeni randevu:** Tarih/saat seçimi ile randevu oluşuyor mu?
- [ ] **İptal / Düzenle** (varsa) çalışıyor mu?

### Finans – Faturalarım (CustomerInvoices)
- [ ] **Liste:** `/Customer/Invoices/Index` – Sadece bu müşteriye ait faturalar görünüyor mu?
- [ ] **Detay:** Fatura detayı (araç dahil) doğru mu?
- [ ] **PDF indir:** İndirilen fatura PDF'inde müşteri adı, **araç (doğru marka/model)**, tutarlar doğru mu?

### Finans – Ödemelerim (CustomerPayments)
- [ ] **Liste:** `/Customer/Payments/Index` – Müşterinin ödemeleri listeleniyor mu?

### Kiralama – Kiralamalarım (CustomerRentals)
- [ ] **Liste:** `/Customer/Rentals/Index` – Müşterinin kiralama sözleşmeleri listeleniyor mu?
- [ ] **Yeni kiralama** (araç seçip sözleşme oluşturma) varsa çalışıyor mu?
- [ ] **Detay** sayfası doğru bilgileri gösteriyor mu?

---

## ARAÇ KİRALAMA – TEST ADIMLARI (MADDE MADDE)

Araç kiralama modülünü sırayla test etmek için aşağıdaki adımları izleyin.

### Admin tarafı – Kiralık araçlar (önce bunlar hazır olmalı)

1. [ ] **Admin** ile giriş yap → **Kiralama** → **Kiralık Araçlar** (`/AdminRentalVehicles/Index`).
2. [ ] Kiralanabilir araç listesi açılıyor mu?
3. [ ] **Yeni araç ekle:** Marka, model, günlük ücret, plaka vb. girip kaydet → Araç listede görünüyor mu?
4. [ ] **Müsait araçlar:** `/AdminRentalVehicles/Available` – Sadece müsait araçlar listeleniyor mu?
5. [ ] Bir aracın **detay** sayfası açılıyor mu? (Düzenle / Sil varsa kontrol et.)

### Admin tarafı – Kiralama sözleşmeleri

6. [ ] **Kiralama** → **Kiralama Sözleşmeleri** (`/AdminRentalAgreements/Index`) → Sözleşme listesi açılıyor mu?
7. [ ] **Yeni sözleşme:** Müşteri seç, kiralık araç seç, başlangıç/bitiş tarihi, tutar, depozito gir → Kaydet → Sözleşme listede görünüyor mu?
8. [ ] **Aktif sözleşmeler:** `/AdminRentalAgreements/Active` – Sadece aktif kiralamalar listeleniyor mu?
9. [ ] **Vadesi geçenler:** `/AdminRentalAgreements/Overdue` – Vadesi geçmiş sözleşmeler listeleniyor mu?
10. [ ] Bir sözleşmenin **detay** sayfası açılıyor mu?
11. [ ] **Düzenle:** Bitiş tarihi, depozito, not vb. güncelle → Kaydediliyor mu?
12. [ ] **Tamamla:** Kiralama bitince “Tamamla” ile bitiş km gir → Durum “Tamamlandı” oluyor mu?
13. [ ] **Sil** (varsa) çalışıyor mu?

### Müşteri tarafı – Geçici araçlar ve kiralama

14. [ ] **Müşteri** hesabı ile giriş yap.
15. [ ] **Geçici Araçlar** (`/Customer/CarsList/Index`) → Kiralanabilir araçlar listeleniyor mu?
16. [ ] Bir araca tıkla → **Detay** sayfası açılıyor mu? (Marka, model, günlük ücret vb.)
17. [ ] **Kirala** / **Kiralama yap** benzeri butonla **Kiralama oluştur** sayfasına gidiliyor mu?
18. [ ] Teslim tarihi, iade tarihi (ve varsa diğer alanlar) gir → **Gönder** / **Oluştur**.
19. [ ] İade tarihi, teslim tarihinden önce seçilirse hata mesajı çıkıyor mu?
20. [ ] Başarılı kayıt sonrası **Kiralamalarım** sayfasına yönlendiriliyor mu? Başarı mesajı görünüyor mu?
21. [ ] **Kiralamalarım** (`/Customer/Rentals/Index`) → Yeni kiralama listede görünüyor mu?
22. [ ] Kiralama **detay** sayfası açılıyor mu? (Araç, tarihler, tutar, varsa fatura bilgisi.)

### Kiralama + Fatura (çapraz)

23. [ ] Admin’de bu kiralama sözleşmesi için **fatura oluşturma** (varsa “Kiralama için fatura” / from-rental) çalışıyor mu?
24. [ ] Müşteri **Faturalarım** sayfasında bu kiralama faturasını görüyor mu?
25. [ ] Kiralama detayında (müşteri veya admin) ilgili fatura / ödeme bilgisi doğru gösteriliyor mu?

---

## ÇAPRAZ KONTROLLER (Admin + Müşteri uyumu)

- [ ] Admin'de oluşturulan **fatura**, ilgili müşteri panelinde "Faturalarım"da görünüyor mu?
- [ ] Müşterinin açtığı **servis talebi**, Admin "Servis Talepleri"nde görünüyor mu?
- [ ] Admin'de faturada gösterilen **araç** (marka/model), o servis talebindeki araç ile aynı mı? (Örn. Opel Mokka)
- [ ] Müşteri **randevu** oluşturduğunda, Admin randevu listesinde görünüyor mu?

---

## NOT

- Admin ve müşteri için farklı kullanıcı hesapları ile giriş yapıp test edin.
- Seed verisi ile geliyorsa, test müşterisi ve servis talebi ID'lerini (örn. 14) not alarak fatura/PDF testlerinde kullanın.
- Hata alırsanız tarayıcı konsolu (F12) ve API yanıtlarını kontrol edin.
