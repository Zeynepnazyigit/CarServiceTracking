🚘 CarServiceTracking
Oto Servis & Araç Kiralama Operasyon Yönetim Platformu

CarServiceTracking; oto servis ve araç kiralama firmalarının operasyonel süreçlerini uçtan uca yönetebilmesi için geliştirilmiş, katmanlı mimari prensiplerine uygun, kurumsal ölçekli bir yazılım projesidir.

Sistem; Web API ve MVC Web UI katmanlarını birbirinden tamamen ayırarak, bakımı kolay, genişletilebilir ve gerçek dünya senaryolarına uygun bir yapı sunar.

📌 Projenin Ortaya Çıkış Amacı

Bu proje geliştirilirken hedeflenen temel noktalar şunlardır:

Oto servis süreçlerini manuel takipten kurtarmak

Servis, randevu ve kiralama işlemlerini dijital ortama taşımak

Araç, müşteri ve finans verilerini merkezi bir yapıda toplamak

UI ve API katmanlarını ayrıştırarak profesyonel mimari yaklaşım sergilemek

Gerçek hayatta kullanılabilir, savunulabilir bir sistem ortaya koymak

CarServiceTracking, akademik bir proje olmasının ötesinde, gerçek bir işletmede çalışabilecek şekilde kurgulanmıştır.

🧱 Mimari Yaklaşım

Proje, Layered Architecture (Katmanlı Mimari) modeli esas alınarak geliştirilmiştir.

Kullanılan Katmanlar
1️⃣ UI.Web (MVC)

Kullanıcı arayüzü

Razor Pages & Views

API ile HttpClient üzerinden iletişim

2️⃣ API

RESTful servisler

JWT tabanlı kimlik doğrulama

Swagger ile endpoint dokümantasyonu

3️⃣ Business

İş kuralları

Servis sınıfları

Validasyon ve mapping işlemleri

4️⃣ Core

Entity tanımları

DTO yapıları

Interface’ler ve enum’lar

5️⃣ Data

Entity Framework Core

Repository & Unit of Work

Migration ve seed işlemleri

6️⃣ Utilities

Result Pattern

Ortak yardımcı sınıflar

🔄 İstek Akışı (Request Lifecycle)
MVC UI 
 → Web API Controller 
   → Business Service 
     → UnitOfWork 
       → Repository 
         → DbContext 
           → SQL Server

Bu yapı sayesinde:

UI katmanı veritabanını asla doğrudan görmez

Tüm iş mantığı tek merkezde toplanır

Kodun sürdürülebilirliği artar

Test edilebilirlik sağlanır

🧪 Kullanılan Teknolojiler
Alan	Teknoloji
Web UI	ASP.NET Core MVC (.NET 8)
API	ASP.NET Core Web API
Backend	C#
ORM	Entity Framework Core
DB	SQL Server / LocalDB
Auth	JWT Bearer Token
Mapping	AutoMapper
Validation	FluentValidation
API Docs	Swagger
Mimari	Repository & Unit of Work
Yardımcı Yapı	Result Pattern
🗂️ Çözüm Yapısı
CarServiceTracking
│
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
🗄️ Veritabanı Tasarımı

Sistem SQL Server / LocalDB kullanmaktadır ve aşağıdaki 17 tablo üzerine kuruludur:

Users – Admin kullanıcıları ve JWT yetkilendirme bilgileri

Customers – Müşteri bilgileri

Cars – Sistemde tanımlı araçlar

CustomerCars – Müşteriye ait şahsi araçlar

ServiceRequests – Servis talepleri

ServiceRecords – Servis geçmiş kayıtları

ServiceAssignments – Servis–mekanik atamaları

ServiceParts – Serviste kullanılan parça kalemleri

Parts – Parça envanteri ve stok bilgileri

ListItems – Marka, model, kategori gibi dinamik listeler

Invoices – Faturalar

Payments – Ödeme kayıtları

Appointments – Servis randevuları

Mechanics – Teknisyen (mekanik) bilgileri

RentalVehicles – Kiralık araçlar

RentalAgreements – Kiralama sözleşmeleri

CompanySettings – Şirket ve sistem ayarları

🔐 Kimlik Doğrulama & Yetkilendirme Yapısı

Sistem iki rol içerir:

Admin

Customer

Yetkilendirme detayları:

Kayıt olan kullanıcılar Customer rolüyle oluşturulur

API tarafında JWT Bearer Token kullanılır

Web UI tarafında Cookie + Session yapısı vardır

Rol bazlı sayfa ve endpoint erişim kontrolü uygulanır

Şifreler hashlenerek saklanır

⚙️ Kurulum ve Çalıştırma
Gereksinimler

.NET 8 SDK

SQL Server veya LocalDB

Visual Studio 2022 / VS Code

Kurulum
git clone <repository-url>
cd CarServiceTracking
dotnet build
Veritabanı Oluşturma
dotnet ef database update \
--project CarServiceTracking.Data \
--startup-project CarServiceTracking.API
Çalışan Servisler

Web API → http://localhost:5130

Swagger → http://localhost:5130/swagger

MVC UI → http://localhost:5070

🔑 Demo Admin Hesabı

E-posta: admin@demo.com

Şifre: 12345678!

📜 Lisans

MIT Lisansı

📆 Proje Durumu

Son Güncelleme: 15 Şubat 2026

Durum: Aktif Geliştirme
