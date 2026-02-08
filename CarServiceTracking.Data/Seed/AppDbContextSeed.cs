using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Contexts;
using CarServiceTracking.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CarServiceTracking.Data.Seed
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // Migrate veritabanını
            await context.Database.MigrateAsync();

            // ListItems seed et
            await SeedListItemsAsync(context);

            // Admin User seed et
            await SeedAdminUserAsync(context);

            // Customer Users ve Customers seed et
            await SeedCustomersAsync(context);

            // Cars seed et
            await SeedCarsAsync(context);

            // Değişiklikleri kaydet
            await context.SaveChangesAsync();
        }

        private static async Task SeedListItemsAsync(AppDbContext context)
        {
            // Eğer zaten ListItems varsa çık
            if (await context.Set<ListItem>().AnyAsync())
                return;

            var listItems = new List<ListItem>
            {
                // CarType (Araç Tipi)
                new ListItem { Name = "Sedan", ListType = "CarType", SortOrder = 1 },
                new ListItem { Name = "SUV", ListType = "CarType", SortOrder = 2 },
                new ListItem { Name = "Hatchback", ListType = "CarType", SortOrder = 3 },
                new ListItem { Name = "Van", ListType = "CarType", SortOrder = 4 },
                new ListItem { Name = "Coupe", ListType = "CarType", SortOrder = 5 },

                // FuelType (Yakıt Tipi)
                new ListItem { Name = "Gasoline", ListType = "FuelType", SortOrder = 1 },
                new ListItem { Name = "Diesel", ListType = "FuelType", SortOrder = 2 },
                new ListItem { Name = "Electric", ListType = "FuelType", SortOrder = 3 },
                new ListItem { Name = "Hybrid", ListType = "FuelType", SortOrder = 4 },
                new ListItem { Name = "LPG", ListType = "FuelType", SortOrder = 5 },

                // TransmissionType (Vites Tipi)
                new ListItem { Name = "Manual", ListType = "TransmissionType", SortOrder = 1 },
                new ListItem { Name = "Automatic", ListType = "TransmissionType", SortOrder = 2 },
                new ListItem { Name = "CVT", ListType = "TransmissionType", SortOrder = 3 },
            };

            await context.Set<ListItem>().AddRangeAsync(listItems);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAdminUserAsync(AppDbContext context)
        {
            // Admin user zaten varsa çık
            var adminExists = await context.Set<User>()
                .AsNoTracking()
                .AnyAsync(u => u.Email == "admin@demo.com");

            if (adminExists)
                return;

            var adminUser = new User
            {
                Email = "admin@demo.com",
                PasswordHash = PasswordHelper.HashPassword("12345678!"),
                Role = "Admin",
                CustomerId = null,
                IsActive = true
            };

            await context.Set<User>().AddAsync(adminUser);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomersAsync(AppDbContext context)
        {
            // Eğer zaten customer users varsa çık
            var customerUsersExist = await context.Set<User>()
                .AsNoTracking()
                .AnyAsync(u => u.Email == "user1@demo.com");

            if (customerUsersExist)
                return;

            // Customer 1
            var user1 = new User
            {
                Email = "user1@demo.com",
                PasswordHash = PasswordHelper.HashPassword("12345678!"),
                Role = "Customer",
                IsActive = true
            };

            var customer1 = new Customer
            {
                FirstName = "Ahmet",
                LastName = "Kara",
                Email = "ahmet.kara@example.com",
                Phone = "+905551234567",
                Address = "Ankara Caddesi No: 123",
                City = "Istanbul",
                Country = "Türkiye",
                PostalCode = "34000",
                CompanyName = null,
                User = user1
            };

            // Customer 2
            var user2 = new User
            {
                Email = "user2@demo.com",
                PasswordHash = PasswordHelper.HashPassword("12345678!"),
                Role = "Customer",
                IsActive = true
            };

            var customer2 = new Customer
            {
                FirstName = "Fatma",
                LastName = "Yılmaz",
                Email = "fatma.yilmaz@example.com",
                Phone = "+905559876543",
                Address = "Bağdat Caddesi No: 456",
                City = "Istanbul",
                Country = "Türkiye",
                PostalCode = "34200",
                CompanyName = null,
                User = user2
            };

            // Customer 3
            var user3 = new User
            {
                Email = "user3@demo.com",
                PasswordHash = PasswordHelper.HashPassword("12345678!"),
                Role = "Customer",
                IsActive = true
            };

            var customer3 = new Customer
            {
                FirstName = "Mehmet",
                LastName = "Şahin",
                Email = "mehmet.sahin@example.com",
                Phone = "+905555555555",
                Address = "Istiklal Caddesi No: 789",
                City = "Ankara",
                Country = "Türkiye",
                PostalCode = "06000",
                CompanyName = null,
                User = user3
            };

            await context.Set<Customer>().AddRangeAsync(customer1, customer2, customer3);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCarsAsync(AppDbContext context)
        {
            // Eğer zaten cars varsa çık
            if (await context.Set<Car>().AnyAsync())
                return;

            // Müşterileri getir
            var customers = await context.Set<Customer>()
                .AsNoTracking()
                .ToListAsync();

            if (customers.Count == 0)
                return;

            // ListItems getir
            var sedanType = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "CarType" && x.Name == "Sedan");

            var suvType = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "CarType" && x.Name == "SUV");

            var gasolineFuel = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "FuelType" && x.Name == "Gasoline");

            var dieselFuel = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "FuelType" && x.Name == "Diesel");

            var automaticTrans = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "TransmissionType" && x.Name == "Automatic");

            var manualTrans = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "TransmissionType" && x.Name == "Manual");

            var cars = new List<Car>
            {
                // Ahmet'in araçları
                new Car
                {
                    PlateNumber = "34ABC1234",
                    Brand = "Toyota",
                    Model = "Camry",
                    Year = 2022,
                    Color = "Beyaz",
                    Mileage = 15000,
                    CustomerId = customers[0].Id,
                    FuelTypeId = gasolineFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = sedanType?.Id
                },
                new Car
                {
                    PlateNumber = "34XYZ5678",
                    Brand = "Honda",
                    Model = "CR-V",
                    Year = 2021,
                    Color = "Siyah",
                    Mileage = 22000,
                    CustomerId = customers[0].Id,
                    FuelTypeId = dieselFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = suvType?.Id
                },

                // Fatma'nın araçları
                new Car
                {
                    PlateNumber = "06DEF9999",
                    Brand = "Mercedes",
                    Model = "E-Class",
                    Year = 2023,
                    Color = "Gümüş",
                    Mileage = 8000,
                    CustomerId = customers[1].Id,
                    FuelTypeId = gasolineFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = sedanType?.Id
                },
                new Car
                {
                    PlateNumber = "06GHI2222",
                    Brand = "Audi",
                    Model = "Q7",
                    Year = 2022,
                    Color = "Kırmızı",
                    Mileage = 18000,
                    CustomerId = customers[1].Id,
                    FuelTypeId = dieselFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = suvType?.Id
                },

                // Mehmet'in araçları
                new Car
                {
                    PlateNumber = "35JKL3333",
                    Brand = "Ford",
                    Model = "Focus",
                    Year = 2020,
                    Color = "Mavi",
                    Mileage = 35000,
                    CustomerId = customers[2].Id,
                    FuelTypeId = gasolineFuel?.Id,
                    TransmissionTypeId = manualTrans?.Id,
                    CarTypeId = sedanType?.Id
                },
                new Car
                {
                    PlateNumber = "35MNO4444",
                    Brand = "Volkswagen",
                    Model = "Passat",
                    Year = 2021,
                    Color = "Gri",
                    Mileage = 28000,
                    CustomerId = customers[2].Id,
                    FuelTypeId = dieselFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = sedanType?.Id
                },
                new Car
                {
                    PlateNumber = "35PQR5555",
                    Brand = "BMW",
                    Model = "X5",
                    Year = 2023,
                    Color = "Siyah",
                    Mileage = 5000,
                    CustomerId = customers[2].Id,
                    FuelTypeId = gasolineFuel?.Id,
                    TransmissionTypeId = automaticTrans?.Id,
                    CarTypeId = suvType?.Id
                }
            };

            await context.Set<Car>().AddRangeAsync(cars);
            await context.SaveChangesAsync();
        }
    }
}
