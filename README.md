# 🚗 CarServiceTracking
## Oto Servis ve Araç Kiralama Operasyon Yönetim Platformu

CarServiceTracking, oto servis ve araç kiralama firmalarının operasyonel süreçlerini uçtan uca yönetebilmesi için geliştirilmiş, katmanlı mimari prensiplerine uygun ve kurumsal ölçekte tasarlanmış bir yazılım sistemidir. Sistem; Web API ve MVC Web UI katmanlarını tamamen birbirinden ayırarak, sürdürülebilir, genişletilebilir ve gerçek dünya senaryolarına uygun bir yapı sunar. Akademik bir proje olmasının ötesinde, gerçek bir işletmede aktif olarak kullanılabilecek şekilde kurgulanmıştır.

## 🎯 Geliştirme Amacı ve Hedefler

CarServiceTracking geliştirilirken aşağıdaki temel hedefler esas alınmıştır:
- Oto servis süreçlerinin manuel takipten kurtarılması
- Servis, randevu ve kiralama operasyonlarının dijital ortama taşınması
- Araç, müşteri ve finansal verilerin merkezi bir yapıda toplanması
- Sunum ve iş mantığı katmanlarının ayrıştırılması
- Profesyonel, savunulabilir ve sürdürülebilir bir mimari ortaya koyulması

Bu doğrultuda CarServiceTracking; servis, bakım ve kiralama süreçlerini tek bir platformda birleştiren bütüncül bir çözüm sunar.

## 🧱 Sistem Mimarisi

┌─────────────────────────────────────────────────────────────┐
│                MVC WebUI – Port 5070                        │
│          (ASP.NET Core MVC, Razor Views)                    │
└────────────────────────┬────────────────────────────────────┘
                         │
                    HttpClient
                         │
                         ▼
┌─────────────────────────────────────────────────────────────┐
│                 RESTful WebAPI – Port 5130                  │
│          (ASP.NET Core, Swagger, JWT Authentication)        │
└────────────────────────┬────────────────────────────────────┘
                         │
                    Dependency Injection
                         │
        ┌────────────────┼────────────────┐
        ▼                ▼                ▼
   Business Layer      Core Layer        Data Layer
   (Services)       (DTOs, Entities)   (EF Core, Repositories)
        │                                 │
        └─────────────────┬───────────────┘
                          ▼
              ┌──────────────────────────┐
              │      SQL Server DB        │
              │   (LocalDB / SQL Server) │
              └──────────────────────────┘

İstek Akışı:
MVC UI → Web API Controller → Business Service → UnitOfWork → Repository → DbContext → SQL Server

Bu yapı sayesinde UI katmanı veritabanına doğrudan erişmez, tüm iş kuralları Business katmanında toplanır, kodun sürdürülebilirliği ve test edilebilirliği artar.

## 🛠️ Teknoloji Yığını

Sunum: ASP.NET Core MVC (.NET 8)  
API: ASP.NET Core Web API (.NET 8)  
İş Mantığı: C# Services + Unit of Work + Generic Repository  
Kimlik Doğrulama: JWT Bearer Token  
Veri Erişim: Entity Framework Core 8.0.22  
Veritabanı: SQL Server / LocalDB  
Mapping: AutoMapper 12.0.1  
Validasyon: FluentValidation 12.1.1  
Sonuç Yapısı: IResult / IDataResult  
Dokümantasyon: Swagger / OpenAPI  

## 📁 Proje Yapısı

CarServiceTracking/
├── CarServiceTracking.UI.Web/
│   ├── Controllers/
│   ├── Views/
│   ├── Services/
│   ├── ViewModels/
│   ├── Models/
│   └── appsettings.json
├── CarServiceTracking.API/
│   ├── Controllers/
│   ├── Middlewares/
│   ├── Program.cs
│   └── appsettings.json
├── CarServiceTracking.Business/
│   ├── Services/
│   ├── Abstract/
│   ├── Mapping/
│   ├── IOC/
│   └── BusinessServiceRegistration.cs
├── CarServiceTracking.Core/
│   ├── DTOs/
│   ├── Entities/
│   ├── Enums/
│   └── Abstracts/
├── CarServiceTracking.Data/
│   ├── Contexts/
│   ├── Repositories/
│   ├── UnitOfWork/
│   ├── Configurations/
│   ├── Migrations/
│   └── Seed/
├── CarServiceTracking.Utilities/
│   └── Results/
└── CarServiceTracking.sln

## ✨ Sistem Modülleri

Yönetimsel Modüller: Dashboard, Araç Yönetimi, Müşteri Yönetimi, Müşteri-Araç Eşleştirme  
Servis Süreçleri: Servis Talepleri, Servis Atamaları, Servis Kayıtları  
Envanter ve Finans: Parça Yönetimi, Fatura İşlemleri, Ödeme Kayıtları  
Kiralama Süreçleri: Kiralık Araç Yönetimi, Kiralama Sözleşmeleri  
Diğer Bileşenler: Randevu Yönetimi, Mekanik Yönetimi, Şirket Ayarları  
Kimlik ve Yetkilendirme: Admin & Customer Rolleri, JWT, Cookie + Session

## 🚀 Kurulum ve Çalıştırma

Gereksinimler: .NET 8 SDK, SQL Server veya LocalDB, Visual Studio 2022 / VS Code, Git

Kurulum:
git clone <repository-url>
cd CarServiceTracking
dotnet build

Veritabanı:
dotnet ef database update --project CarServiceTracking.Data --startup-project CarServiceTracking.API

Çalıştırma:
WebAPI: http://localhost:5130
Swagger: http://localhost:5130/swagger
MVC UI: http://localhost:5070

## 📊 Veritabanı Yapısı

Toplam 17 tablo:
1. Users
2. Customers
3. Cars
4. CustomerCars
5. ServiceRequests
6. ServiceRecords
7. ServiceParts
8. ServiceAssignments
9. Parts
10. ListItems
11. Invoices
12. Payments
13. Appointments
14. Mechanics
15. RentalVehicles
16. RentalAgreements
17. CompanySettings

## 🧩 Business Servisleri

CarService, CustomerService, CustomerCarService, ServiceRequestService, ServiceAssignmentService, CustomerAuthService, UserAuthService, JwtTokenService, ListItemService, PartService, InvoiceService, PaymentService, AppointmentService, MechanicService, RentalService, CompanySettingsService

## 🔐 Demo Admin Hesabı

E-posta: admin@demo.com  
Şifre: 12345678!

## 📄 Lisans

MIT Lisansı

## 📌 Proje Durumu

Son Güncelleme: 15 Şubat 2026  
Sürüm: 1.0.0  
Durum: Aktif Geliştirme
