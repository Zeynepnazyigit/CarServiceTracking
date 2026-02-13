using CarServiceTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarServiceTracking.Data.Seed
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            SeedListItems(modelBuilder);
            SeedRentalVehicles(modelBuilder);
            SeedParts(modelBuilder);
        }

        private static void SeedListItems(ModelBuilder modelBuilder)
        {
            var listItems = new List<ListItem>();

            // 1. Araç Tipleri (CarType)
            listItems.AddRange(new[]
            {
                new ListItem { Id = 1, Name = "Sedan", ListType = "CarType", SortOrder = 1, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 2, Name = "Hatchback", ListType = "CarType", SortOrder = 2, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 3, Name = "SUV", ListType = "CarType", SortOrder = 3, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 4, Name = "Station Wagon", ListType = "CarType", SortOrder = 4, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 5, Name = "Pickup", ListType = "CarType", SortOrder = 5, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 6, Name = "Minivan", ListType = "CarType", SortOrder = 6, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 7, Name = "Coupe", ListType = "CarType", SortOrder = 7, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 8, Name = "Cabrio", ListType = "CarType", SortOrder = 8, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now }
            });

            // 2. Yakıt Tipleri (FuelType)
            listItems.AddRange(new[]
            {
                new ListItem { Id = 11, Name = "Benzin", ListType = "FuelType", SortOrder = 1, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 12, Name = "Dizel", ListType = "FuelType", SortOrder = 2, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 13, Name = "LPG", ListType = "FuelType", SortOrder = 3, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 14, Name = "Elektrik", ListType = "FuelType", SortOrder = 4, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 15, Name = "Hibrit", ListType = "FuelType", SortOrder = 5, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 16, Name = "Plug-in Hibrit", ListType = "FuelType", SortOrder = 6, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now }
            });

            // 3. Vites Tipleri (TransmissionType)
            listItems.AddRange(new[]
            {
                new ListItem { Id = 21, Name = "Manuel", ListType = "TransmissionType", SortOrder = 1, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 22, Name = "Otomatik", ListType = "TransmissionType", SortOrder = 2, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 23, Name = "Yarı Otomatik", ListType = "TransmissionType", SortOrder = 3, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 24, Name = "CVT", ListType = "TransmissionType", SortOrder = 4, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 25, Name = "DSG", ListType = "TransmissionType", SortOrder = 5, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now }
            });

            // 4. Müşteri Tipleri (CustomerType)
            listItems.AddRange(new[]
            {
                new ListItem { Id = 31, Name = "Bireysel", ListType = "CustomerType", SortOrder = 1, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now },
                new ListItem { Id = 32, Name = "Kurumsal", ListType = "CustomerType", SortOrder = 2, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now }
            });

            modelBuilder.Entity<ListItem>().HasData(listItems);
        }

        private static void SeedRentalVehicles(ModelBuilder modelBuilder)
        {
            var rentalVehicles = new List<RentalVehicle>
            {
                // 1. Toyota Corolla - Ekonomik Sedan
                new RentalVehicle
                {
                    Id = 1,
                    PlateNumber = "34 ABC 123",
                    Brand = "Toyota",
                    Model = "Corolla",
                    Year = 2023,
                    FuelType = "Benzin",
                    TransmissionType = "Otomatik",
                    Color = "Beyaz",
                    Mileage = 15000,
                    DailyRate = 750.00m,
                    IsAvailable = true,
                    Notes = "Klima, ABS, Airbag, Geri Görüş Kamerası",
                    ImageUrl = "https://www.arabazzi.com/images/yuklemeler/corolla-14079.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 2. Volkswagen Passat - Business Class
                new RentalVehicle
                {
                    Id = 2,
                    PlateNumber = "06 XYZ 456",
                    Brand = "Volkswagen",
                    Model = "Passat",
                    Year = 2022,
                    FuelType = "Dizel",
                    TransmissionType = "DSG",
                    Color = "Siyah",
                    Mileage = 28000,
                    DailyRate = 900.00m,
                    IsAvailable = true,
                    Notes = "Deri Koltuk, Sunroof, Navigasyon, Apple CarPlay",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/passat223.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 3. Renault Megane - Kompakt
                new RentalVehicle
                {
                    Id = 3,
                    PlateNumber = "35 DEF 789",
                    Brand = "Renault",
                    Model = "Megane",
                    Year = 2024,
                    FuelType = "Benzin",
                    TransmissionType = "Manuel",
                    Color = "Kırmızı",
                    Mileage = 5000,
                    DailyRate = 650.00m,
                    IsAvailable = true,
                    Notes = "Bluetooth, Klima, Park Sensörü",
                    ImageUrl = "https://www.arabazzi.com/images/yuklemeler/renault-megane-sedan2340.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 4. BMW 3 Serisi - Premium
                new RentalVehicle
                {
                    Id = 4,
                    PlateNumber = "16 GHI 321",
                    Brand = "BMW",
                    Model = "320i",
                    Year = 2023,
                    FuelType = "Benzin",
                    TransmissionType = "Otomatik",
                    Color = "Gri",
                    Mileage = 12000,
                    DailyRate = 1500.00m,
                    IsAvailable = false,
                    Notes = "Premium Sound, Deri Döşeme, Adaptif Hız Kontrolü, M Sport Paket",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/3-serisi22.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 5. Ford Focus - Ekonomik
                new RentalVehicle
                {
                    Id = 5,
                    PlateNumber = "41 JKL 654",
                    Brand = "Ford",
                    Model = "Focus",
                    Year = 2021,
                    FuelType = "Dizel",
                    TransmissionType = "Manuel",
                    Color = "Mavi",
                    Mileage = 45000,
                    DailyRate = 550.00m,
                    IsAvailable = true,
                    Notes = "Park Sensörü, Klima, ABS, Ekonomik Yakıt Tüketimi",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/focus-2019244.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 6. Mercedes-Benz C180 - Lüks
                new RentalVehicle
                {
                    Id = 6,
                    PlateNumber = "34 LMN 987",
                    Brand = "Mercedes-Benz",
                    Model = "C180",
                    Year = 2023,
                    FuelType = "Benzin",
                    TransmissionType = "Otomatik",
                    Color = "Beyaz",
                    Mileage = 8000,
                    DailyRate = 1800.00m,
                    IsAvailable = true,
                    Notes = "AMG Line, Burmester Ses Sistemi, Panoramik Tavan, 360° Kamera",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/c-serisi123.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 7. Hyundai Tucson - SUV
                new RentalVehicle
                {
                    Id = 7,
                    PlateNumber = "07 OPQ 246",
                    Brand = "Hyundai",
                    Model = "Tucson",
                    Year = 2024,
                    FuelType = "Hibrit",
                    TransmissionType = "Otomatik",
                    Color = "Yeşil",
                    Mileage = 3000,
                    DailyRate = 1100.00m,
                    IsAvailable = true,
                    Notes = "Hibrit Motor, 4x4, Büyük Bagaj, Şerit Takip Sistemi",
                    ImageUrl = "https://www.arabazzi.com/images/yuklemeler/hyundai-tucson-nasil8975.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 8. Audi A4 - Premium Sedan
                new RentalVehicle
                {
                    Id = 8,
                    PlateNumber = "34 RST 135",
                    Brand = "Audi",
                    Model = "A4",
                    Year = 2022,
                    FuelType = "Dizel",
                    TransmissionType = "S-Tronic",
                    Color = "Lacivert",
                    Mileage = 22000,
                    DailyRate = 1400.00m,
                    IsAvailable = true,
                    Notes = "Quattro 4x4, Virtual Cockpit, Matrix LED Far, B&O Ses Sistemi",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/a48.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                // 9. Fiat Egea - Ekonomik Sedan
                new RentalVehicle
                {
                    Id = 9,
                    PlateNumber = "35 UVW 864",
                    Brand = "Fiat",
                    Model = "Egea",
                    Year = 2023,
                    FuelType = "LPG",
                    TransmissionType = "Manuel",
                    Color = "Gümüş",
                    Mileage = 18000,
                    DailyRate = 450.00m,
                    IsAvailable = true,
                    Notes = "LPG'li, Ekonomik, Geniş İç Mekan, USB Girişi",
                    ImageUrl = "https://www.arabazzi.com/images/model_gorsel/egea-sedan62.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                }
            };

            modelBuilder.Entity<RentalVehicle>().HasData(rentalVehicles);
        }

        private static void SeedParts(ModelBuilder modelBuilder)
        {
            var parts = new List<Part>
            {
                // Motor Parçaları
                new Part
                {
                    Id = 1,
                    PartCode = "MF-001",
                    PartName = "Yağ Filtresi",
                    Category = "Motor",
                    Description = "Universal yağ filtresi, çoğu benzinli araçla uyumlu",
                    UnitPrice = 150.00m,
                    StockQuantity = 50,
                    MinStockLevel = 10,
                    Supplier = "Bosch Türkiye",
                    SupplierContact = "0212 555 10 10",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 2,
                    PartCode = "MF-002",
                    PartName = "Hava Filtresi",
                    Category = "Motor",
                    Description = "Motor hava filtresi, 1.4-1.6 motor hacmi",
                    UnitPrice = 120.00m,
                    StockQuantity = 40,
                    MinStockLevel = 8,
                    Supplier = "Mann Filter",
                    SupplierContact = "0216 444 20 20",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 3,
                    PartCode = "MF-003",
                    PartName = "Buji Seti (4 Adet)",
                    Category = "Motor",
                    Description = "İridyum buji seti, 4 silindirli motorlar için",
                    UnitPrice = 480.00m,
                    StockQuantity = 25,
                    MinStockLevel = 5,
                    Supplier = "NGK",
                    SupplierContact = "0212 333 40 40",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 4,
                    PartCode = "MF-004",
                    PartName = "Triger Kayışı Seti",
                    Category = "Motor",
                    Description = "Triger kayışı + gergi rulmanı seti",
                    UnitPrice = 1250.00m,
                    StockQuantity = 12,
                    MinStockLevel = 3,
                    Supplier = "Gates",
                    SupplierContact = "0216 555 30 30",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },

                // Fren Sistemi
                new Part
                {
                    Id = 5,
                    PartCode = "FR-001",
                    PartName = "Ön Fren Balata Seti",
                    Category = "Fren",
                    Description = "Ön aks fren balata takımı, seramik",
                    UnitPrice = 350.00m,
                    StockQuantity = 30,
                    MinStockLevel = 6,
                    Supplier = "Ferodo",
                    SupplierContact = "0212 444 50 50",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 6,
                    PartCode = "FR-002",
                    PartName = "Arka Fren Balata Seti",
                    Category = "Fren",
                    Description = "Arka aks fren balata takımı",
                    UnitPrice = 280.00m,
                    StockQuantity = 28,
                    MinStockLevel = 6,
                    Supplier = "Ferodo",
                    SupplierContact = "0212 444 50 50",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 7,
                    PartCode = "FR-003",
                    PartName = "Fren Diski (Ön - Çift)",
                    Category = "Fren",
                    Description = "Ön aks fren disk takımı, havalandırmalı",
                    UnitPrice = 900.00m,
                    StockQuantity = 15,
                    MinStockLevel = 4,
                    Supplier = "Brembo",
                    SupplierContact = "0216 666 70 70",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },

                // Süspansiyon
                new Part
                {
                    Id = 8,
                    PartCode = "SS-001",
                    PartName = "Ön Amortisör (Çift)",
                    Category = "Süspansiyon",
                    Description = "Ön aks gaz amortisör takımı",
                    UnitPrice = 1800.00m,
                    StockQuantity = 8,
                    MinStockLevel = 3,
                    Supplier = "Monroe",
                    SupplierContact = "0212 777 80 80",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 9,
                    PartCode = "SS-002",
                    PartName = "Rotil (Çift)",
                    Category = "Süspansiyon",
                    Description = "Ön aks rotil takımı",
                    UnitPrice = 450.00m,
                    StockQuantity = 20,
                    MinStockLevel = 5,
                    Supplier = "TRW",
                    SupplierContact = "0216 888 90 90",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },

                // Elektrik
                new Part
                {
                    Id = 10,
                    PartCode = "EL-001",
                    PartName = "Akü 60Ah",
                    Category = "Elektrik",
                    Description = "12V 60Ah başlatma aküsü",
                    UnitPrice = 2200.00m,
                    StockQuantity = 10,
                    MinStockLevel = 3,
                    Supplier = "Mutlu Akü",
                    SupplierContact = "0212 999 10 10",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 11,
                    PartCode = "EL-002",
                    PartName = "Far Ampulü H7 (Çift)",
                    Category = "Elektrik",
                    Description = "H7 halojen far ampulü seti",
                    UnitPrice = 180.00m,
                    StockQuantity = 35,
                    MinStockLevel = 10,
                    Supplier = "Philips",
                    SupplierContact = "0216 111 20 20",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },

                // Sarf Malzemeler
                new Part
                {
                    Id = 12,
                    PartCode = "SM-001",
                    PartName = "Motor Yağı 5W-30 (4L)",
                    Category = "Sarf Malzeme",
                    Description = "Tam sentetik motor yağı 5W-30, 4 litre",
                    UnitPrice = 750.00m,
                    StockQuantity = 60,
                    MinStockLevel = 15,
                    Supplier = "Castrol",
                    SupplierContact = "0212 222 30 30",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 13,
                    PartCode = "SM-002",
                    PartName = "Antifriz (3L)",
                    Category = "Sarf Malzeme",
                    Description = "Uzun ömürlü antifriz, -40°C koruma",
                    UnitPrice = 220.00m,
                    StockQuantity = 25,
                    MinStockLevel = 8,
                    Supplier = "Motul",
                    SupplierContact = "0216 333 40 40",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 14,
                    PartCode = "SM-003",
                    PartName = "Fren Hidroliği DOT4 (500ml)",
                    Category = "Sarf Malzeme",
                    Description = "DOT4 fren hidrolik yağı",
                    UnitPrice = 95.00m,
                    StockQuantity = 40,
                    MinStockLevel = 10,
                    Supplier = "Bosch Türkiye",
                    SupplierContact = "0212 555 10 10",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },

                // Düşük stoklu parçalar (test için)
                new Part
                {
                    Id = 15,
                    PartCode = "KL-001",
                    PartName = "Klima Kompresörü",
                    Category = "Klima",
                    Description = "Universal klima kompresörü",
                    UnitPrice = 4500.00m,
                    StockQuantity = 2,
                    MinStockLevel = 3,
                    Supplier = "Denso",
                    SupplierContact = "0212 444 60 60",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Part
                {
                    Id = 16,
                    PartCode = "MF-005",
                    PartName = "Turbo Şarj",
                    Category = "Motor",
                    Description = "1.5 dCi turbo şarj ünitesi",
                    UnitPrice = 8500.00m,
                    StockQuantity = 1,
                    MinStockLevel = 2,
                    Supplier = "Garrett",
                    SupplierContact = "0216 555 70 70",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                }
            };

            modelBuilder.Entity<Part>().HasData(parts);
        }
    }
}