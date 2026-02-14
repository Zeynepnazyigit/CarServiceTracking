# 🚘 CarServiceTracking  
## Oto Servis ve Araç Kiralama Operasyon Yönetim Platformu

CarServiceTracking; oto servis ve araç kiralama firmalarının servis, bakım, randevu, envanter, finans ve kiralama süreçlerini uçtan uca yönetebilmesi amacıyla geliştirilmiş, katmanlı mimari prensiplerine uygun, kurumsal ölçekli bir yazılım projesidir. Sistem; Web API ve MVC Web UI katmanlarını tamamen birbirinden ayırarak, bakımı kolay, genişletilebilir ve gerçek dünya senaryolarına uygun profesyonel bir mimari sunar. Proje, akademik bir çalışma olmasının ötesinde gerçek bir işletmede aktif olarak kullanılabilecek şekilde tasarlanmıştır.

## 🎯 Projenin Ortaya Çıkış Amacı
- Oto servis süreçlerini manuel takipten kurtarmak
- Servis, bakım, randevu ve kiralama işlemlerini dijitalleştirmek
- Araç, müşteri ve finans verilerini merkezi bir sistemde toplamak
- UI ve API katmanlarını ayrıştırarak sürdürülebilir mimari kurmak
- Savunulabilir, ölçeklenebilir ve profesyonel bir sistem geliştirmek

## 🧱 Sistem Mimarisi
Sunum Katmanı  
MVC Web UI (ASP.NET Core MVC, .NET 8) – Port: 5070  
UI, Web API ile HttpClient üzerinden haberleşir.

API Katmanı  
RESTful Web API (ASP.NET Core Web API, .NET 8) – Port: 5130  
JWT ile kimlik doğrulama sağlanır.  
Swagger / OpenAPI ile endpoint’ler dokümante edilmiştir.

Business Katmanı  
C# Service sınıfları  
Tüm iş kuralları ve doğrulamalar bu katmanda yer alır.  
Unit of Work ile transaction yönetimi sağlanır.

Core Katmanı  
Entity sınıfları  
DTO’lar  
Enum’lar ve abstract / interface yapılar

Data Katmanı  
Entity Framework Core  
Generic Repository Pattern  
DbContext ve veri erişim implementasyonları

Veritabanı  
SQL Server / LocalDB

İstek Akışı  
Kullanıcı → MVC Web UI → Web API → Business Service → Unit of Work → Repository → DbContext → SQL Server

Bu mimari sayesinde UI katmanı veritabanına doğrudan erişmez, iş kuralları merkezi bir yapıda toplanır ve sistem test edilebilir, sürdürülebilir ve ölçeklenebilir hale gelir.

## 🛠️ Teknoloji Altyapısı
- Sunum: ASP.NET Core MVC (.NET 8)
- API: ASP.NET Core Web API (.NET 8)
- İş Mantığı: C# Services, Unit of Work, Generic Repository
- ORM: Entity Framework Core 8.0.22
- Veritabanı: SQL Server / LocalDB
- Kimlik Doğrulama: JWT Bearer Token
- Mapping: AutoMapper 12.0.1
- Validasyon: FluentValidation 12.1.1
- Sonuç Yapısı: IResult / IDataResult
- Dokümantasyon: Swagger / OpenAPI

## 📁 Proje Yapısı
CarServiceTracking  
-UI.Web (Controllers, Views, Services, ViewModels, Models)  
-API (Controllers, Middlewares, Program.cs)  
-Business (Services, Abstract, Mapping, IOC)  
-Core (Entities, DTOs, Enums, Abstracts)  
-Data (Contexts, Repositories, UnitOfWork, Configurations, Migrations, Seed)  
-Utilities (Result Pattern)  
-CarServiceTracking.sln

## ✨ Sistem Modülleri
•Yönetimsel Modüller  
•Dashboard  
•Araç Yönetimi  
•Müşteri Yönetimi  
•Müşteri-Araç Eşleştirme

•Servis Süreçleri  
•Servis Talepleri  
•Servis Atamaları  
•Servis Kayıtları

•Envanter ve Finans  
•Parça Yönetimi  
•Fatura İşlemleri  
•Ödeme Kayıtları

•Kiralama Süreçleri  
•Kiralık Araç Yönetimi  
•Kiralama Sözleşmeleri

•Diğer Bileşenler  
•Randevu Yönetimi  
•Mekanik Yönetimi  
•Şirket Ayarları

## 🗄️ Veritabanı Tasarımı (17 Tablo)
1. Users
2. Customers
3. Cars
4. CustomerCars
5. ServiceRequests
6. ServiceRecords
7. ServiceAssignments
8. ServiceParts
9. Parts
10. ListItems
11. Invoices
12. Payments
13. Appointments
14. Mechanics
15. RentalVehicles
16. RentalAgreements
17. CompanySettings

## 🔐 Kimlik Doğrulama ve Yetkilendirme
- Sistem iki rol içerir: Admin ve Customer
- Kayıt olan kullanıcılar varsayılan olarak Customer rolündedir
- API tarafında JWT Bearer Token kullanılır
- Web UI tarafında Cookie + Session ile oturum yönetimi yapılır
- Rol bazlı sayfa ve endpoint erişim kontrolü uygulanır
- Şifreler hashlenerek saklanır

## ⚙️ Kurulum ve Çalıştırma
-Gereksinimler  
.NET 8 SDK  
SQL Server veya LocalDB  
Visual Studio 2022 / VS Code

-Kurulum  
git clone <repo-url>  
cd CarServiceTracking  
dotnet build  
dotnet ef database update --project CarServiceTracking.Data --startup-project CarServiceTracking.API

-Çalışan Servisler  
Web API: http://localhost:5130  
Swagger: http://localhost:5130/swagger  
MVC UI: http://localhost:5070

## 🔑 Demo Admin Hesabı
E-posta: admin@demo.com  
Şifre: 12345678!

## 📜 Lisans
MIT Lisansı

## 📆 Proje Durumu
Son Güncelleme: 15 Şubat 2026  
Durum: Aktif Geliştirme
