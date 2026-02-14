# 🚘 CarServiceTracking  
## Oto Servis & Araç Kiralama Operasyon Yönetim Platformu

CarServiceTracking; oto servis ve araç kiralama firmalarının operasyonel süreçlerini uçtan uca yönetebilmesi için geliştirilmiş, katmanlı mimari prensiplerine uygun, kurumsal ölçekli bir yazılım projesidir.

Sistem; Web API ve MVC Web UI katmanlarını birbirinden tamamen ayırarak, bakımı kolay, genişletilebilir ve gerçek dünya senaryolarına uygun bir yapı sunar.

---

## 📌 Projenin Ortaya Çıkış Amacı

Bu proje geliştirilirken hedeflenen temel noktalar şunlardır:

1. Oto servis süreçlerini manuel takipten kurtarmak
2. Servis, randevu ve kiralama işlemlerini dijital ortama taşımak
3. Araç, müşteri ve finans verilerini merkezi bir yapıda toplamak
4. UI ve API katmanlarını ayrıştırarak profesyonel mimari yaklaşım sergilemek
5. Gerçek hayatta kullanılabilir, savunulabilir bir sistem ortaya koymak

CarServiceTracking, akademik bir proje olmasının ötesinde, gerçek bir işletmede çalışabilecek şekilde kurgulanmıştır.

---

## 🧱 Mimari Yaklaşım

Proje, Layered Architecture (Katmanlı Mimari) modeli esas alınarak geliştirilmiştir.

### Kullanılan Katmanlar

#### 1. UI.Web (MVC)
- Kullanıcı arayüzü
- Razor Pages & Views
- API ile HttpClient üzerinden iletişim

#### 2. API
- RESTful servisler
- JWT tabanlı kimlik doğrulama
- Swagger ile endpoint dokümantasyonu

#### 3. Business
- İş kuralları
- Servis sınıfları
- Validasyon ve mapping işlemleri

#### 4. Core
- Entity tanımları
- DTO yapıları
- Interface’ler ve enum’lar

#### 5. Data
- Entity Framework Core
- Repository & Unit of Work
- Migration ve seed işlemleri

#### 6. Utilities
- Result Pattern
- Ortak yardımcı sınıflar

---

## 🔄 İstek Akışı (Request Lifecycle)

MVC UI  
→ Web API Controller  
→ Business Service  
→ UnitOfWork  
→ Repository  
→ DbContext  
→ SQL Server

Bu yapı sayesinde:

1. UI katmanı veritabanını asla doğrudan görmez
2. Tüm iş mantığı tek merkezde toplanır
3. Kodun sürdürülebilirliği artar
4. Test edilebilirlik sağlanır

---

## 🧪 Kullanılan Teknolojiler

| Alan | Teknoloji |
|-----|----------|
| Web UI | ASP.NET Core MVC (.NET 8) |
| API | ASP.NET Core Web API |
| Backend | C# |
| ORM | Entity Framework Core |
| DB | SQL Server / LocalDB |
| Auth | JWT Bearer Token |
| Mapping | AutoMapper |
| Validation | FluentValidation |
| API Docs | Swagger |
| Mimari | Repository & Unit of Work |
| Yardımcı Yapı | Result Pattern |

---

## 🗂️ Çözüm Yapısı

CarServiceTracking  
├─ UI.Web  
│  ├─ Controllers  
│  ├─ Views  
│  ├─ Services  
│  ├─ ViewModels  
│  ├─ Models  
│  └─ appsettings.json  
│  
├─ API  
│  ├─ Controllers  
│  ├─ Middlewares  
│  ├─ Program.cs  
│  └─ appsettings.json  
│  
├─ Business  
│  ├─ Abstract  
│  ├─ Services  
│  ├─ Mapping  
│  ├─ IOC  
│  └─ BusinessServiceRegistration.cs  
│  
├─ Core  
│  ├─ Entities  
│  ├─ DTOs  
│  ├─ Enums  
│  └─ Abstracts  
│  
├─ Data  
│  ├─ Contexts  
│  ├─ Repositories  
│  ├─ UnitOfWork  
│  ├─ Configurations  
│  ├─ Migrations  
│  └─ Seed  
│  
├─ Utilities  
│  └─ Results  
│  
└─ CarServiceTracking.sln  

---

## 🗄️ Veritabanı Tasarımı

Sistem SQL Server / LocalDB kullanmaktadır ve aşağıdaki 17 tablo üzerine kuruludur:

1. Users – Admin kullanıcıları ve JWT yetkilendirme bilgileri  
2. Customers – Müşteri bilgileri  
3. Cars – Sistemde tanımlı araçlar  
4. CustomerCars – Müşteriye ait şahsi araçlar  
5. ServiceRequests – Servis talepleri  
6. ServiceRecords – Servis geçmiş kayıtları  
7. ServiceAssignments – Servis–mekanik atamaları  
8. ServiceParts – Serviste kullanılan parça kalemleri  
9. Parts – Parça envanteri ve stok bilgileri  
10. ListItems – Marka, model, kategori gibi dinamik listeler  
11. Invoices – Faturalar  
12. Payments – Ödeme kayıtları  
13. Appointments – Servis randevuları  
14. Mechanics – Teknisyen (mekanik) bilgileri  
15. RentalVehicles – Kiralık araçlar  
16. RentalAgreements – Kiralama sözleşmeleri  
17. CompanySettings – Şirket ve sistem ayarları  

---

## 🔐 Kimlik Doğrulama & Yetkilendirme Yapısı

Sistem iki rol içerir:

1. Admin  
2. Customer  

Yetkilendirme detayları:

- Kayıt olan kullanıcılar Customer rolüyle oluşturulur
- API tarafında JWT Bearer Token kullanılır
- Web UI tarafında Cookie + Session yapısı vardır
- Rol bazlı sayfa ve endpoint erişim kontrolü uygulanır
- Şifreler hashlenerek saklanır

---

## ⚙️ Kurulum ve Çalıştırma

### Gereksinimler

1. .NET 8 SDK
2. SQL Server veya LocalDB
3. Visual Studio 2022 / VS Code

### Kurulum

git clone <repository-url>  
cd CarServiceTracking  
dotnet build  

### Veritabanı Oluşturma

dotnet ef database update  
--project CarServiceTracking.Data  
--startup-project CarServiceTracking.API  

### Çalışan Servisler

- Web API: http://localhost:5130  
- Swagger: http://localhost:5130/swagger  
- MVC UI: http://localhost:5070  

---

## 🔑 Demo Admin Hesabı

- E-posta: admin@demo.com  
- Şifre: 12345678!  

---

## 📜 Lisans

MIT Lisansı

---

## 📆 Proje Durumu

- Son Güncelleme: 15 Şubat 2026  
- Durum: Aktif Geliştirme
