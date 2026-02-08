using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Car
{
    public int Id { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string? Color { get; set; }

    public string? ChassisNumber { get; set; }

    public int? Mileage { get; set; }

    public string? EngineNumber { get; set; }

    public string? Notes { get; set; }

    public int CustomerId { get; set; }

    public int? FuelTypeId { get; set; }

    public int? TransmissionTypeId { get; set; }

    public int? CarTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ListItem? CarType { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<CustomerCar> CustomerCars { get; set; } = new List<CustomerCar>();

    public virtual ListItem? FuelType { get; set; }

    public virtual ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ListItem? TransmissionType { get; set; }
}
