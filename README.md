# CarServiceTracking

Oto servis ve araç kiralama yönetim sistemi.

## Gereksinimler

- .NET 8
- SQL Server

## Kurulum

1. Projeyi indir
2. Veritabanını oluştur:
   dotnet ef database update --project CarServiceTracking.Data --startup-project CarServiceTracking.API
3. API ve UI.Web projelerini aynı anda çalıştır

## Çalıştırma

- Web: http://localhost:5070
- API: http://localhost:5130

## Giriş

Admin: admin@demo.com / 12345678!
