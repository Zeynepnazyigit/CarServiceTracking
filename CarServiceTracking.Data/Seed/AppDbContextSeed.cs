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

            // Mechanics seed et
            await SeedMechanicsAsync(context);

            // CustomerCars seed et
            await SeedCustomerCarsAsync(context);

            // ServiceRequests seed et
            await SeedServiceRequestsAsync(context);

            // Appointments seed et
            await SeedAppointmentsAsync(context);

            // Invoices seed et
            await SeedInvoicesAsync(context);

            // Payments seed et
            await SeedPaymentsAsync(context);

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
                new ListItem { Name = "Benzin", ListType = "FuelType", SortOrder = 1 },
                new ListItem { Name = "Dizel", ListType = "FuelType", SortOrder = 2 },
                new ListItem { Name = "Elektrik", ListType = "FuelType", SortOrder = 3 },
                new ListItem { Name = "Hibrit", ListType = "FuelType", SortOrder = 4 },
                new ListItem { Name = "LPG", ListType = "FuelType", SortOrder = 5 },

                // TransmissionType (Vites Tipi)
                new ListItem { Name = "Manuel", ListType = "TransmissionType", SortOrder = 1 },
                new ListItem { Name = "Otomatik", ListType = "TransmissionType", SortOrder = 2 },
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
                .FirstOrDefaultAsync(x => x.ListType == "FuelType" && x.Name == "Benzin");

            var dieselFuel = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "FuelType" && x.Name == "Dizel");

            var automaticTrans = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "TransmissionType" && x.Name == "Otomatik");

            var manualTrans = await context.Set<ListItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ListType == "TransmissionType" && x.Name == "Manuel");

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

        private static async Task SeedMechanicsAsync(AppDbContext context)
        {
            if (await context.Set<Mechanic>().AnyAsync())
                return;

            var mechanics = new List<Mechanic>
            {
                new Mechanic
                {
                    FirstName = "Ali",
                    LastName = "Usta",
                    Phone = "+905551001010",
                    Email = "ali.usta@servis.com",
                    Specialization = "Motor",
                    HourlyRate = 250.00m,
                    HireDate = new DateTime(2022, 3, 15),
                    Notes = "Kıdemli motor teknisyeni"
                },
                new Mechanic
                {
                    FirstName = "Veli",
                    LastName = "Demir",
                    Phone = "+905552002020",
                    Email = "veli.demir@servis.com",
                    Specialization = "Fren & Süspansiyon",
                    HourlyRate = 220.00m,
                    HireDate = new DateTime(2023, 1, 10),
                    Notes = "Fren ve süspansiyon uzmanı"
                },
                new Mechanic
                {
                    FirstName = "Hasan",
                    LastName = "Çelik",
                    Phone = "+905553003030",
                    Email = "hasan.celik@servis.com",
                    Specialization = "Elektrik & Elektronik",
                    HourlyRate = 280.00m,
                    HireDate = new DateTime(2021, 6, 1),
                    Notes = "Araç elektrik ve elektronik sistemleri"
                },
                new Mechanic
                {
                    FirstName = "Osman",
                    LastName = "Yılmaz",
                    Phone = "+905554004040",
                    Email = "osman.yilmaz@servis.com",
                    Specialization = "Klima & Karoseri",
                    HourlyRate = 200.00m,
                    HireDate = new DateTime(2023, 9, 20)
                }
            };

            await context.Set<Mechanic>().AddRangeAsync(mechanics);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomerCarsAsync(AppDbContext context)
        {
            if (await context.Set<CustomerCar>().AnyAsync())
                return;

            var customers = await context.Set<Customer>().AsNoTracking().ToListAsync();
            if (customers.Count == 0) return;

            var customerCars = new List<CustomerCar>
            {
                new CustomerCar
                {
                    CustomerId = customers[0].Id,
                    BrandModel = "Toyota Camry",
                    PlateNumber = "34ABC1234",
                    Year = 2022,
                    Mileage = 15000,
                    Color = "Beyaz",
                    IsInService = false
                },
                new CustomerCar
                {
                    CustomerId = customers[0].Id,
                    BrandModel = "Honda CR-V",
                    PlateNumber = "34XYZ5678",
                    Year = 2021,
                    Mileage = 22000,
                    Color = "Siyah",
                    IsInService = true
                },
                new CustomerCar
                {
                    CustomerId = customers[1].Id,
                    BrandModel = "Mercedes E-Class",
                    PlateNumber = "06DEF9999",
                    Year = 2023,
                    Mileage = 8000,
                    Color = "Gümüş",
                    IsInService = false
                },
                new CustomerCar
                {
                    CustomerId = customers[2].Id,
                    BrandModel = "Ford Focus",
                    PlateNumber = "35JKL3333",
                    Year = 2020,
                    Mileage = 35000,
                    Color = "Mavi",
                    IsInService = false
                }
            };

            await context.Set<CustomerCar>().AddRangeAsync(customerCars);
            await context.SaveChangesAsync();
        }

        private static async Task SeedServiceRequestsAsync(AppDbContext context)
        {
            if (await context.Set<ServiceRequest>().AnyAsync())
                return;

            var customers = await context.Set<Customer>().AsNoTracking().ToListAsync();
            var cars = await context.Set<Car>().AsNoTracking().ToListAsync();
            if (customers.Count == 0 || cars.Count == 0) return;

            var serviceRequests = new List<ServiceRequest>
            {
                new ServiceRequest
                {
                    CustomerId = customers[0].Id,
                    CarId = cars[0].Id,
                    ProblemDescription = "Motor yağı değişimi ve filtre bakımı gerekiyor",
                    CreatedAt = DateTime.Now.AddDays(-10),
                    Status = Core.Enums.ServiceRequestStatus.Completed,
                    ServicePrice = 850.00m,
                    AdminNote = "Yağ ve filtre değişimi yapıldı"
                },
                new ServiceRequest
                {
                    CustomerId = customers[0].Id,
                    CarId = cars[1].Id,
                    ProblemDescription = "Fren balatası aşınmış, ses yapıyor",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    Status = Core.Enums.ServiceRequestStatus.InService,
                    PreferredDate = DateTime.Now.AddDays(1),
                    AdminNote = "Fren balatası siparişi verildi"
                },
                new ServiceRequest
                {
                    CustomerId = customers[1].Id,
                    CarId = cars[2].Id,
                    ProblemDescription = "Klima soğutmuyor, gaz dolumu gerekebilir",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Status = Core.Enums.ServiceRequestStatus.Pending,
                    PreferredDate = DateTime.Now.AddDays(3)
                },
                new ServiceRequest
                {
                    CustomerId = customers[2].Id,
                    CarId = cars[4].Id,
                    ProblemDescription = "Periyodik bakım zamanı geldi (30.000 km)",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    Status = Core.Enums.ServiceRequestStatus.Completed,
                    ServicePrice = 2500.00m,
                    AdminNote = "30.000 km periyodik bakım tamamlandı"
                },
                new ServiceRequest
                {
                    CustomerId = customers[2].Id,
                    CarId = cars[5].Id,
                    ProblemDescription = "Ön süspansiyon sert vuruyor, kontrol gerekli",
                    CreatedAt = DateTime.Now,
                    Status = Core.Enums.ServiceRequestStatus.Pending,
                    PreferredDate = DateTime.Now.AddDays(5)
                }
            };

            await context.Set<ServiceRequest>().AddRangeAsync(serviceRequests);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAppointmentsAsync(AppDbContext context)
        {
            if (await context.Set<Appointment>().AnyAsync())
                return;

            var customers = await context.Set<Customer>().AsNoTracking().ToListAsync();
            var cars = await context.Set<Car>().AsNoTracking().ToListAsync();
            if (customers.Count == 0 || cars.Count == 0) return;

            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    CustomerId = customers[0].Id,
                    CarId = cars[0].Id,
                    AppointmentDate = DateTime.Today.AddDays(2).AddHours(10),
                    TimeSlot = "10:00 - 11:00",
                    Status = Core.Enums.AppointmentStatus.Confirmed,
                    ServiceType = "Yağ Değişimi",
                    Description = "Periyodik yağ ve filtre değişimi",
                    ConfirmedAt = DateTime.Now.AddDays(-1)
                },
                new Appointment
                {
                    CustomerId = customers[1].Id,
                    CarId = cars[2].Id,
                    AppointmentDate = DateTime.Today.AddDays(3).AddHours(14),
                    TimeSlot = "14:00 - 15:00",
                    Status = Core.Enums.AppointmentStatus.Pending,
                    ServiceType = "Klima Bakımı",
                    Description = "Klima gazı dolumu ve kontrol"
                },
                new Appointment
                {
                    CustomerId = customers[2].Id,
                    CarId = cars[4].Id,
                    AppointmentDate = DateTime.Today.AddDays(-2).AddHours(9),
                    TimeSlot = "09:00 - 10:00",
                    Status = Core.Enums.AppointmentStatus.Completed,
                    ServiceType = "Periyodik Bakım",
                    Description = "30.000 km periyodik bakım"
                },
                new Appointment
                {
                    CustomerId = customers[0].Id,
                    CarId = cars[1].Id,
                    AppointmentDate = DateTime.Today.AddDays(5).AddHours(11),
                    TimeSlot = "11:00 - 12:00",
                    Status = Core.Enums.AppointmentStatus.Pending,
                    ServiceType = "Fren Bakımı",
                    Description = "Fren balata değişimi"
                }
            };

            await context.Set<Appointment>().AddRangeAsync(appointments);
            await context.SaveChangesAsync();
        }

        private static async Task SeedInvoicesAsync(AppDbContext context)
        {
            if (await context.Set<Invoice>().AnyAsync())
                return;

            var serviceRequests = await context.Set<ServiceRequest>()
                .AsNoTracking()
                .Where(sr => sr.Status == Core.Enums.ServiceRequestStatus.Completed)
                .ToListAsync();

            if (serviceRequests.Count == 0) return;

            var invoiceNumber = 1;
            var invoices = new List<Invoice>();

            foreach (var sr in serviceRequests)
            {
                var partsTotal = sr.ServicePrice.HasValue ? sr.ServicePrice.Value * 0.6m : 500m;
                var laborCost = sr.ServicePrice.HasValue ? sr.ServicePrice.Value * 0.4m : 350m;
                var subTotal = partsTotal + laborCost;
                var taxRate = 20m;
                var taxAmount = subTotal * taxRate / 100;
                var grandTotal = subTotal + taxAmount;

                invoices.Add(new Invoice
                {
                    InvoiceNumber = $"INV-2026-{invoiceNumber:D4}",
                    InvoiceDate = sr.CreatedAt.AddDays(2),
                    ServiceRequestId = sr.Id,
                    CustomerId = sr.CustomerId,
                    PartsTotal = Math.Round(partsTotal, 2),
                    LaborCost = Math.Round(laborCost, 2),
                    SubTotal = Math.Round(subTotal, 2),
                    TaxRate = taxRate,
                    TaxAmount = Math.Round(taxAmount, 2),
                    GrandTotal = Math.Round(grandTotal, 2),
                    PaymentStatus = invoiceNumber == 1
                        ? Core.Enums.PaymentStatus.Paid
                        : Core.Enums.PaymentStatus.Pending,
                    PaidAmount = invoiceNumber == 1 ? Math.Round(grandTotal, 2) : 0m,
                    RemainingAmount = invoiceNumber == 1 ? 0m : Math.Round(grandTotal, 2),
                    DueDate = sr.CreatedAt.AddDays(30),
                    Notes = "Servis tamamlandıktan sonra oluşturuldu"
                });
                invoiceNumber++;
            }

            await context.Set<Invoice>().AddRangeAsync(invoices);
            await context.SaveChangesAsync();
        }

        private static async Task SeedPaymentsAsync(AppDbContext context)
        {
            if (await context.Set<Payment>().AnyAsync())
                return;

            // Ödenmiş faturaları getir
            var paidInvoices = await context.Set<Invoice>()
                .AsNoTracking()
                .Where(i => i.PaymentStatus == Core.Enums.PaymentStatus.Paid)
                .ToListAsync();

            if (paidInvoices.Count == 0) return;

            var payments = new List<Payment>();

            foreach (var invoice in paidInvoices)
            {
                payments.Add(new Payment
                {
                    InvoiceId = invoice.Id,
                    PaymentDate = invoice.InvoiceDate.AddDays(5),
                    Amount = invoice.GrandTotal,
                    PaymentMethod = Core.Enums.PaymentMethod.CreditCard,
                    TransactionId = $"TXN-{DateTime.Now.Ticks}",
                    Reference = $"REF-{invoice.InvoiceNumber}",
                    Notes = "Kredi kartı ile ödendi"
                });
            }

            await context.Set<Payment>().AddRangeAsync(payments);
            await context.SaveChangesAsync();
        }
    }
}
