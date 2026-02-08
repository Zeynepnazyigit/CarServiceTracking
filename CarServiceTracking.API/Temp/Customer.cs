using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? TaxNumber { get; set; }

    public string? CompanyName { get; set; }

    public string? Notes { get; set; }

    public int? CustomerTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<CustomerCar> CustomerCars { get; set; } = new List<CustomerCar>();

    public virtual ListItem? CustomerType { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<RentalAgreement> RentalAgreements { get; set; } = new List<RentalAgreement>();

    public virtual ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual User? User { get; set; }
}
